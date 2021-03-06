﻿using KadGen.ClassTracker.Domain;
using KadGen.Common.Repository;

namespace KadGen.ClassTracker.Repository
{
    public class CourseRepository
             : BaseEfRepository<Course, int, EfCourse, ClassTrackerDbContext>
    {
        public CourseRepository()
            : base(
                  getDbSet: dc => dc.Courses,
                  getPKey: e => e.Id,
                  mapEntityToDomain: Mapper.MapEntityToDomain,
                  mapDomainToEntity: Mapper.MapDomainToEntity)
        { }

        internal class Mapper
        {
            public static Course MapEntityToDomainForOrganization(EfCourse entity, Organization organization)
            {
                return new Course(entity.Id, organization, entity.CatalogNumber, entity.Name);
            }
            public static Course MapEntityToDomain(EfCourse entity)
            {
                // TODO: Figure out how to share mappings, like here for org
                return new Course(entity.Id, null, entity.CatalogNumber, entity.Name);
            }

            public static EfCourse MapDomainToEntity(Course domain)
            {
                var entity = new EfCourse();
                entity.Id = domain.Id;
                entity.Name = domain.Name;
                return entity;
            }
        }
    }
}

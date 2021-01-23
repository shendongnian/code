    namespace DataLayer
    {
        public class EfDbContext : DbContext
        {
            public virtual IDbSet<ThingEntity> ThingEntities { get; set; }
        }
    
        public class ThingEntity
        {
            public int Id { get; set; }
        }
    }

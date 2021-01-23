    public class YouDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<Object2>
                .HasMany(o1 => o1.Objects)
                .WithOptional(o2 => o2.Object2);
    
            base.OnModelCreating(mb);
        }
    }

    public class NoiseModelContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<Car>().Map(p => p.Requires("Type").HasValue("Car"));
            modelBuilder.Entity<Plane>().Map(p => p.Requires("Type").HasValue("Plane"));
        }
    
        public DbSet<NoiseOrigin> NoiseOrigins { get; set; }
    
        public DbSet<NoiseRecord> NoiseRecords { get; set; }
    }

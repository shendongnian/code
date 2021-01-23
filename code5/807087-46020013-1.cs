    public class VegaDbContext : DbContext
    {
        public DbSet<Make> Makes{get;set;}
        public DbSet<Feature> Features{get;set;}
        public VegaDbContext(DbContextOptions<VegaDbContext> options):base(options)        
        {           
        }
        // we override the OnModelCreating method here.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf=> new {vf.VehicleId, vf.FeatureId});
        }
    }

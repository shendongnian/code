    public class DDBContext : DbContext
    {
        public DDBContext()
        {
          /* ... */
        }
        // add the DbSet
        public DbSet<Comment> Comments { get; set; }
        //... additional models ommitted
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DDBContext, Configuration>());
        }
    }

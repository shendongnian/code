    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {
            Database.SetInitializer<MyDbContext>(new MyInitializer());
        }
    
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<Movie>().Property(m => m.SumOfAllRatings)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
        }
    }

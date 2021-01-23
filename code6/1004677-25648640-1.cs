    public class AppContext : DbContext
    {
        public DbSet<NavigationPropertyClass> NavigationPropertyClasses { get; set; }
        public DbSet<Base> Bases { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Derived1>().ToTable("Derived1");
            modelBuilder.Entity<Derived2>().ToTable("Derived2");
        }
    }

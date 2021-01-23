    public class AppContext : DbContext
    {
        public DbSet<SomeOtherBaseClass> SomeOtherBaseClasses { get; set; }
        public DbSet<Base> Bases { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Derived1>().ToTable("Derived1");
            modelBuilder.Entity<Derived2>().ToTable("Derived2");
            modelBuilder.Entity<NavigationPropertyClass>().ToTable("NavigationPropertyClass");
            modelBuilder.Entity<NavigationPropertyClass>()
                .HasRequired(x => x.Derived1)
                .WithRequiredDependent(x => x.NavigationProperty);
        }
    }

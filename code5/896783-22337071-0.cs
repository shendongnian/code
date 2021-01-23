    public class MyContext : DbContext
    {
        public DbSet<MyClass> MyClass;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyClass>().Property(x => x.MyDecimalProperty).HasPrecision(7, 0);
        }
    }

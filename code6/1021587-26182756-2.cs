    public class MyDbContext : DbContext, IMyProj1DbContext, IMyProj2DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

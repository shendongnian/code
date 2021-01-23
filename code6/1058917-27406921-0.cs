    public class SomeContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Tyre> Tires { get; set; }
    }

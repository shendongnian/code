    public class CarDbContext : DbContext
    {
        public CarDbContext()
            : base("CarDbConnectionString")
        {
            Database.SetInitializer<CarDbContext>(new CreateDatabaseIfNotExists<CarDbContext>());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
    }
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        public string CarName { get; set; }
        public virtual Fuel FuelType { get; set; }    // set as virtual
    }
    public class Fuel
    {
        [Key, ForeignKey("Car")]                      // primary and foreign key
        public int FuelID { get; set; }
        public string Name { get; set; }
        public virtual Car Car { get; set; }          // must include a navigation property for the Principal entity
    }

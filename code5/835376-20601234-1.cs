    public class Car
    {
        [Key]
        public int CarID { get; set; }
        public string CarName { get; set; }
        public int FuelTypeID { get; set; }
        [ForeignKey("FuelTypeID")]
        public virtual Fuel FuelType { get; set; }
    }
    public class Fuel
    {
        public int FuelID { get; set; }
        public string Name { get; set; }
    }
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

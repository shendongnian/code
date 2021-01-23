    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
    public class Driver
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }

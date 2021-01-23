    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public int? DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
    public class Driver
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public int? CarId { get; set; }
        public virtual Car Car { get; set; }
    }

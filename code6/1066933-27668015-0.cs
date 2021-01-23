    public class Car
    {
        public int Id { get; set; }
        public Guid CarGuid { get; set; }
        public string Name { get; set; }
        public virtual CarDetails CarDetails { get; set; }
    }
    public class CarDetails
    {
        [Key, ForeignKey("Car")]
        public int Id { get; set; }
        public Guid CarGuid { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public virtual Car Car { get; set; }
    }

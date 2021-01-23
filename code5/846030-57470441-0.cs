C#
    public class Garage
    {
        public int Id { get; set; }
        public virtual List<Car> Cars { get; set; }
        public virtual List<Motorcycle> Motorcycles { get; set; }
    
        public Garage()
        {
            Cars = new List<Car>();
            Motorcycles = new List<Motorcycle>();
        }
    }
    
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public int GarageId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
    
    public class Car : Vehicle
    {
        [ForeignKey("GarageId")]
        public virtual Garage Garage { get; set; }
        // some more properties here...
    }
    
    public class Motorcycle : Vehicle
    {
        [ForeignKey("GarageId")]
        public virtual Garage Garage { get; set; }
        // some more properties here...
    }

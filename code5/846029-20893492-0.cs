    public class Garage
    {
        public int Id { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
        public Garage()
        {
            Vehicles = new List<Vehicle>();
        }
    }
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int GarageId { get; set; }
        public virtual Garage Garage { get; set; }
    }
    public class Car : Vehicle
    {
        // some more properties here...
    }
    public class Motorcycle : Vehicle
    {
        // some more properties here...
    }

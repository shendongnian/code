    public class VehiclesContainer // Your container class
    {
        [XmlArray("vehicles")]
        [XmlArrayItem("vehicle", typeof(Vehicle))]
        [XmlArrayItem("car", typeof(Car))]
        [XmlArrayItem("boat", typeof(Boat))]
        public List<Vehicle> Vehicles = new List<Vehicle>();
    }

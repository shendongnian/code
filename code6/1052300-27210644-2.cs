    [XmlRoot("vehicles")]
    public class VehicleList
    {
        [XmlElement("vehicle", typeof(Vehicle))]
        [XmlElement("car", typeof(Car))]
        [XmlElement("boat", typeof(Boat))]
        public List<Vehicle> Vehicles = new List<Vehicle>();
    }

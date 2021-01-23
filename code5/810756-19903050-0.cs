    public class Vehicle
    {
        [XmlElement("Name")]
        public List<Vehicle> Names {get { return names; }}
        private readonly List<Vehicle> names = new List<Vehicle>();
    }

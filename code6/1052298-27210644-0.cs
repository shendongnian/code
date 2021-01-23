    public class Car : Vehicle
    {
        [XmlAttribute]
        public int NumberOfDoors { get; set; }
        public override bool Drive() { return false; }
    }
    public class Boat : Vehicle
    {
        [XmlAttribute]
        public int NumberOfSeats { get; set; }
    }

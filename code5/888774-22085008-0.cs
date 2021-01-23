    [XmlRoot("car")]
    public class Automobile
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
    }

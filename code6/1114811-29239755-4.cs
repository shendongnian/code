    public class Property
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
        [XmlAttribute]
        public string Category { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
    }
    [XmlRoot("Camera_Properties")]
    public class CameraPropertyList
    {
        [XmlElement("Property")]
        public List<Property> Properties { get; set; }
    }

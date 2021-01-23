    public class SubSection
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlElement]
        public string Summary { get; set; }
        [XmlElement]
        public string Name { get; set; }
    }

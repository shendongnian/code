    [Serializable]
    public class Profile
    {
        [XmlAttribute("name")]
        public string NameAttribute { get; set; }
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public int Age { get; set; }
        [XmlElement]
        public string Country { get; set; }
    }

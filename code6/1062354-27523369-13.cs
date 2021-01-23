    [XmlRoot("ls")]
    public class Request
    {
        [XmlAttribute("ver")]
        public string Version { get; set; }
        [XmlElement("ChildClass2",typeof(class2))]
        [XmlElement("ChildClass3",typeof(class3))]
        public object Data { get; set; }
    }
    public class class2
    {
        [XmlElement("login")]
        public string Property1 { get; set; }
    }
    public class class3
    {
        [XmlElement("User")]
        public string Property1 { get; set; }
    }

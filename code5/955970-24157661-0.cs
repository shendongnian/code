    [XmlRoot]
    public class A
    {
        [XmlAttribute]
        public string Period { get; set; }
        [XmlElement("C")]
        public List<C> B { get; set; }
    }

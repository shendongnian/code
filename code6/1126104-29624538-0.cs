    public class TestXml
    {
        [XmlArray("model")]
        [XmlArrayItem("prop")]
        public List<Prop> Props { get; set; }
    }
        
    
    public class Prop
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAttribute("value")]
        public string Value { get; set; }
    }

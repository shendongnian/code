    public class Parameter
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
        [XmlAttribute("value")]
        public Int32 Value { get; set; }
    }
    [XmlType(TypeName = "listener")]
    public class Listener
    {
        [XmlAttribute("type")]
        public String Type { get; set; }
        [XmlElement("parameter")]
        public Parameter[] Parameters;
    }

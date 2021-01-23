    public class XmlEntities
    {
        [XmlRoot("root")]
        public class Root
        {
            [XmlElement("elementwrapper")]
            public Elementwrapper Elementwrapper { get; set; }
    
            [XmlAttribute("attr1")]
            public string attr1;
        }
    
        public class Elementwrapper
        {
            [XmlElement("secondElementwrapper")]
            public SecondElementwrapper SecondElementwrapper { get; set; }
        }
    
        public class SecondElementwrapper
        {
            [XmlElement("element")]
            public string Element { get; set; }
    
            [XmlElement("differentelement")]
            public string Differentelement { get; set; }
        }        
    }

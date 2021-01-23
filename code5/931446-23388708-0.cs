    [XmlRoot("parameter")]
    public class Parameter {
        [XmlElement("component")]
        public Component Component {get;set;}
    }
    public class Component {
        [XmlElement("attributes")]
        public List<Attribute> Attributes {get;set;}
    }

    [Serializable()]
    public class Person
    {
        [System.Xml.Serialization.XmlElement("Name")]
        public string Name{ get; set; }
    
        [System.Xml.Serialization.XmlElement("Phone")]
        public int Phone { get; set; }
    
        [System.Xml.Serialization.XmlElement("Address ")]
        public string Address { get; set; }
    }

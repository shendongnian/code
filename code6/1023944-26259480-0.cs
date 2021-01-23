    [Serializable()]
    [XmlRoot(ElementName = "Node1", Namespace = "http://www.CIP4.org/JDFSchema_1_1")]
    public class SOMETHING
    {
        //attributes
        [XmlAttribute("Att1")]
        public string Att1 = "";
        [XmlAttribute("Att2")]
        public string Att2 = "";
        [XmlElement("Node2")]
        public string node2 = "";
    }

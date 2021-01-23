    [Serializable] //Root
    [XmlRoot(ElementName = "InfXml", Namespace="the namespace URI")]
    public class InfXml
    {
        [XmlAttribute(AttributeName = "id")] //attribute
        public string Id { get; set; }
        public bool ShouldSerializeId() //Should serialize, only serializes if not null.
        {
            return !string.IsNullOrEmpty(Id); //This is only for optional fields.
        }
        [XmlElement(ElementName = "Identification")] //Non optional group.
        public Identification Identification{ get; set; }
        [XmlElement(ElementName = "Adress")] //Optional group.
        public Adress Adress{ get; set; }
        public bool ShouldSerializeAdress()
        {
            return Adress!= null;
        }
    }

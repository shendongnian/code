    [DataContract]
    [XmlRoot("item")]
    [XmlType]
    public class ResDesItem
    {
        [XmlElement("PoBox")]
        [DataMember]
        public string PoBox { get; set; }
        [XmlElement("City1")]
        [DataMember]
        public string City1 { get; set; }
        [XmlElement("Country")]
        [DataMember]
        public string Country { get; set; }
    }

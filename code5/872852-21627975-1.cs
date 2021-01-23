    [DataContract]
    [XmlRoot("ResDes")]
    [XmlType]
    public class ResDes
    {
        [XmlElement("item")]
        [DataMember]
        public List<ResDesItem> ResDesItem { get; set; }
    }

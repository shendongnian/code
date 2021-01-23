    [Serializable]
    [XmlRoot("item")]
    [XmlType]
    public class ResDesItem
    {
        [XmlElement("PoBox")]
        public string PoBox { get; set; }
        [XmlElement("City1")]
        public string City1 { get; set; }
        [XmlElement("Country")]
        public string Country { get; set; }
    }

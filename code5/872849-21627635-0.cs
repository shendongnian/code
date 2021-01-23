    [Serializable]
    [XmlRoot("ResDes")]
    [XmlType]
    public class ResDes
    {
        [XmlElement("item")]
        public List<ResDesItem> ResDesItem { get; set; }
    }

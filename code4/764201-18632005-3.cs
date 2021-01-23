    public enum DataType
    {
        [XmlEnum("Static Data")]
        StaticData,
        [XmlEnum("Dynamic Data")]
        DynamicData,
        [XmlEnum("Not Selected")]
        NotSelected
    }
    [XmlRoot("xml")]
    public class SomeRootElement
    {
        private readonly List<DataItem> items = new List<DataItem>();
        [XmlElement("data")]
        public List<DataItem> Items { get { return items; } }
    }
    public class DataItem
    {
        [XmlElement("find")]
        public string Find { get; set; }
        [XmlElement("data_type")]
        public DataType DataType { get; set; }
        [XmlElement("static_value")]
        public string StaticValue { get; set; }
        [XmlElement("field_name")]
        public string FieldName { get; set; }
        [XmlElement("table_name")]
        public string TableName { get; set; }
    }

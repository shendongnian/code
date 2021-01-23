    public class YourSerializedClass
    {
        [XmlArrayItem("Filter")]
        public List<Filter> ContentList { get; set; }
    }
    public class Filter
    {
        [XmlElement("FilterItem")]
        public List<string> FilterItems { get; set; }
    }

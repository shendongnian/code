    [XmlRoot("SiteSettings")]
    public class SerializableSiteSettings
    {
        [XmlArray("sortOptions")]
        [XmlArrayItem("add", typeof(NameValuePair))]
        public List<NameValuePair> SortOptions { get; set; }
    }
    public class NameValuePair
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
    }

    [XmlRoot("items")]
    public class MyItems
    {
        [XmlElement("item")]
        public List<int> Items { get; set; }
    }

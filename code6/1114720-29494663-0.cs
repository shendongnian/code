    public class CFgroup
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("CFgroup")]
        public List<CFgroup> Groups { get; set; }
        [XmlElement("item")]
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        [XmlAttribute("available")]
        public string Available { get; set; }
        [XmlText]
        public string Value { get; set; }
    }

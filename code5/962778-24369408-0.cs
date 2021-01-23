    public class Item
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAttribute("href", Namespace="http://www.w3.org/1999/xlink")]
        public string Url { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class recipe
    {
        public string title { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("li", IsNullable = false)]
        public string[] ingredients { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("li", IsNullable = false)]
        public string[] instructions { get; set; }
    }

    [Serializable]
    [XmlRoot(Namespace = "", ElementName = "Mary")]
    public class Mary
    {
        [XmlElement("Frank")]
        public Frank[] Frank { get; set; }
    }
    [Serializable]
    public class Frank
    {
        [XmlElement("Joe")]
        public Joe[] Joe { get; set; }
    }
    [Serializable]
    public class Joe
    {
        [XmlElement("Susan")]
        public Susan[] Susan { get; set; }
    }
    [Serializable]
    public class Susan
    {
        [XmlElement("Stuff")]
        public string Stuff { get; set; }
    }

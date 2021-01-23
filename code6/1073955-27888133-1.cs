    [XmlRoot("recipe")]
    public class Receipe
    {
        [XmlElement("title")]
        public string Title { get; set; }
    
        [XmlArray("ingredients")]
        [XmlArrayItem("li")]
        public string[] Ingridients { get; set; }
    
        [XmlArray("instructions")]
        [XmlArrayItem("li")]
        public string[] Instructions { get; set; }
    }

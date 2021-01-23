    public class Stage
    {
        [XmlAttribute("label")]
        public string label { get; set; }
        [XmlAttribute("pack")]
        public string pack { get; set; }
        [XmlArray("Sets")]
        [XmlArrayItem("Set")]
        public List<Set> Sets = new List<Set>();
    }

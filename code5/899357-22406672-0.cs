    [XmlRoot("response")]
    public class Response
    {
        [XmlArray(ElementName = "texts")]
        [XmlArrayItem(ElementName = "text")]
        public List<Text> Texts { get; set; }
    }
    public class Text
    {
        [XmlText]
        public string TextValue { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

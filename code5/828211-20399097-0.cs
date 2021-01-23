    [Serializable]
    public class Field
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
        public Field()
        {
        }
    }

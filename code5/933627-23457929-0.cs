    public class A_el
    {
        [System.Xml.Serialization.XmlAttribute("ID")]
        public int id { get; set; }
        [System.Xml.Serialization.XmlArray(ElementName = "Fields")]
        [System.Xml.Serialization.XmlArrayItem("Field", typeof(Field))]
        public Field[] Fields { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Field
    {
        public string Title { get; set; }
        public string Value { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Hint { get; set; }
    }

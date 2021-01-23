    [XmlRoot(Namespace = "http://www.test.com/myclass", ElementName = "Req")]
    public class Request
    {
        [XmlElement("R1", Namespace = "")]
        public string R1 { get; set; }
        public bool ShouldSerializeR1()  { return !string.IsNullOrWhiteSpace(R1); }
        [XmlAttribute("schemaLocation", Namespace = "")]
        public string xsiSchemaLocation = "http://www.test.com/myclass.xsd";
    }

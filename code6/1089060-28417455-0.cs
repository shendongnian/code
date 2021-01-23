    [XmlRoot(ElementName = "MyRoot", Namespace = MyElement.ElementNamespace)]
    public class MyElement
    {
        public const string ElementNamespace = "http://www.mynamespace.com";
        public const string SchemaInstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";
        [XmlAttribute("schemaLocation", Namespace = SchemaInstanceNamespace)]
        public string SchemaLocation = "http://www.mynamespace.com/schema.xsd";
        public string Content { get; set; }
    }

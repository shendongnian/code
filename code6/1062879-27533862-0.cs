    [XmlRoot("ClassToSerialize", Namespace="http://www.nrf-arts.org/namespace")]
    public class ClassToSerialize
    {
        public static XmlSerializerNamespaces GetAdditionalNamespaces()
        {
            XmlSerializerNamespaces xsNS = new XmlSerializerNamespaces();
            xsNS.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xsNS.Add("Test", "http://www.Test.org/");
            return xsNS;
        }
        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string XSDSchemaLocation
        {
            get
            {
                return "http://www.123.org/namespace C:\\Schema\\ClassToSerialize.xsd";
            }
            set
            {
                // Do nothing - fake property.
            }
        }
        [XmlAttribute()]
        public string Type { get; set; }
        [XmlAttribute()]
        public string Name { get; set; }
        [XmlElement("Address")]
        public Address AddressField { get; set; }
    }

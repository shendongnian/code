    [XmlRoot(Namespace = "somenamespace",
     ElementName = "invalidMessageFault")]
    public class InvalidMessageFault : IXmlSerializable
    {
        public string FaultCode { get; set; }
        public string FaultText { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("faultCode", FaultCode);
            writer.WriteElementString("faultReference", "Client WebService");
            writer.WriteElementString("faultText", FaultText);
        }
    }
    

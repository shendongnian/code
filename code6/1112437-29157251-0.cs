    Change the code to:
    
        [XmlRoot("wor:invalidMessageFault xmlns:wor=\"some namespace\"")]
        public class RawXMLString : IXmlSerializable
        {
            private string xmlTemplate = @"<faultCode>{0}</faultCode>
              <faultReference>Client WebService</faultReference>
              <faultText>{1}</faultText>";
    
        public string FaultCode { get; set; }
    
        public string FaultText { get; set; }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
        }
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteRaw(string.Format(xmlTemplate,FaultCode,FaultText));
        }
    }

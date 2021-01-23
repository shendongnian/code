     public class IncidentEvent : IXmlSerializable
     {
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string EventTypeText { get; set; }
        
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            return null;
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("ex", "EventTypeText", "http://foo", EventTypeText);
        }
     }

    public class DevicePolicy : IXmlSerializable
    {
        public enum SharingLevel
        {
            Unrestricted,
            Blocked
        }
        public SharingLevel SHARING_LEVEL = SharingLevel.Blocked;
        public bool REQUIRES_AUTHENTICATION = false;
        public List<string> MANAGED_LIST = new List<string>();
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException(); //TODO
        }
        public void WriteXml(XmlWriter writer)
        {
            //Root
            writer.WriteStartElement("map");
            
            //The element for "SharingLevel SHARING_LEVEL"
            writer.WriteStartElement("string");
            writer.WriteAttributeString("name", "SHARING_LEVEL");
            writer.WriteString(SHARING_LEVEL.ToString());
            writer.WriteEndElement();
            //The element for "bool REQUIRES_AUTHENTICATION"
            writer.WriteStartElement("boolean");
            throw new NotImplementedException(); //TODO
        }
    }

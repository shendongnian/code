    public class Modification : IXmlSerializable
    {
        public string Name;
        public string Value;
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            Name = reader.Name;
            Value = reader.ReadElementContentAsString();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(Value);
        }
    }

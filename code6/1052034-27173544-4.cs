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
            reader.ReadStartElement();
            Name = reader.Name;
            Value = reader.ReadElementContentAsString();
            reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString(Name, Value);
        }
    }

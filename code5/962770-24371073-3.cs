    [Serializable]
    public class Serializetest : IXmlSerializable
    {
        public Serializetest()
        {
            Empty = string.Empty;
        }
        public string Empty { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Empty");
            writer.WriteValue(Empty);
            writer.WriteEndElement();
        }
    }

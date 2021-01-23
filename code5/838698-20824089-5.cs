    [XmlRoot("metadata")]
    public class XmlSerializableDictionary<TValue> : Dictionary<string, TValue>, IXmlSerializable where TValue : class
    {
        private const string XmlKeyName = "key";
        private const string XmlValueName = "entry";
        public void WriteXml(XmlWriter writer)
        {
            var valueSerializer = new XmlSerializer(typeof (TValue));
            var ns = new XmlSerializerNamespaces(); ns.Add("", "");
            foreach (var key in Keys)
            {
                writer.WriteStartElement(XmlValueName);
                writer.WriteAttributeString(XmlKeyName, string.Empty, key);
                var value = this[key];
                // Only serialize the value if value is not null, otherwise write the 
                // empty XML element.
                if (value != null) 
                {
                    valueSerializer.Serialize(writer, value, ns);
                }
                writer.WriteEndElement();
            }
        }
        public void ReadXml(XmlReader reader) { /* left out */ }
        public XmlSchema GetSchema() { return null; }
    }

    [XmlRoot("metadata")]
    public class SerializableDictionary<TValue> : Dictionary<string, TValue>, IXmlSerializable where TValue : class
    {
        private const string XmlKeyName = "key";
        private const string XmlValueName = "entry";
        public void WriteXml(XmlWriter writer)
        {
            var valueSerializer = new XmlSerializer(typeof (TValue));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
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
        public void ReadXml(XmlReader reader)
        {
            var valueSerializer = new XmlSerializer(typeof (TValue));
            var wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (!wasEmpty)
            {
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement(XmlValueName);
                    var key = string.Empty;
                    var value = (TValue)valueSerializer.Deserialize(reader);
                    reader.ReadEndElement();
                    if (reader.HasAttributes)
                    {
                        reader.MoveToAttribute(XmlKeyName);
                        key = reader.GetAttribute(XmlKeyName);
                    }
                    Add(key, value);
                    reader.MoveToContent();
                }
            }
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }

    public class MyCollection<T> : Collection<T>, IXmlSerializable where T: class 
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            var serializer = new XmlSerializer(typeof(T));
            var wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.IsEmptyElement)
                {
                    reader.Read();
                    Items.Add(null);
                    continue;
                }
                var item = (T)serializer.Deserialize(reader);
                Items.Add(item);
            }
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            var serializer = new XmlSerializer(typeof (T));
            foreach (var myFrac in Items)
            {
                serializer.Serialize(writer, myFrac);
            }
        }
    }

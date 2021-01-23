    [XmlRoot(ElementName = "ArrayOfRoomRateResult")]
    public class MyList : List<RoomRateResponse>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            var serializer = new XmlSerializer(typeof(RoomRateResponse));
            var wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                var item = (RoomRateResponse)serializer.Deserialize(reader);
                Add(item);
            }
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            var serializer = new XmlSerializer(typeof(RoomRateResponse));
            foreach (var val in this)
            {
                serializer.Serialize(writer, val);
            }
        }
    }

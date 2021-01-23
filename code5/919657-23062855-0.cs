    [XmlRoot("parameters")]
    internal class Parameters
    {
        public string Source;
    
        public string Day;
        public List<Item> Items;
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Source = reader.ReadElementContentAsString("source", "");
            Day = reader.ReadElementContentAsString("day", "");
            var newItems = new List<Item>();
            while (reader.LocalName == "item")
            {
                var newItem = new Item();
                newItem.ReadXml(reader);
                newItems.Add(newItem);
            }
            Items = newItems;
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("source", Source);
            writer.WriteElementString("day", Day);
            foreach (Item item in Items)
            {
                writer.WriteStartElement("item");
                item.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }

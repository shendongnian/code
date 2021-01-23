    public class ImageProperties : IXmlSerializable
    {
        public string ImageName { get; set; }
        public string ImageFilePath { get; set; }
        public List<IFilter> Filters { get; set; }
        
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            string startEle = reader.Name;            
            reader.ReadStartElement();
            Filters = new List<IFilter>();
            do
            {
                switch (reader.Name)
                {
                    case "imgName":
                        ImageName = reader.ReadElementContentAsString();
                        break;
                    case "imgFilePath":
                        ImageFilePath = reader.ReadElementContentAsString();
                        break;
                    case "filters":
                        reader.ReadStartElement("filters");
                        while (reader.Name.Equals("iFilter"))
                        {
                            XmlSerializer filterSerializer = new XmlSerializer(Type.GetType(reader.GetAttribute("type")));
                            reader.ReadStartElement("iFilter");
                            Filters.Add((IFilter)filterSerializer.Deserialize(reader));
                            reader.ReadEndElement();
                        }
                        reader.ReadEndElement();
                        break;                    
                }
            } while (reader.Name != startEle);
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("imgName", ImageName);
            writer.WriteElementString("imgFilePath", ImageFilePath);
            writer.WriteStartElement("filters");            
            foreach (IFilter filter in Filters)
            {
                writer.WriteStartElement("iFilter");
                writer.WriteAttributeString("type", filter.GetType().FullName);
                XmlSerializer filterSerializer = new XmlSerializer(filter.GetType());
                filterSerializer.Serialize(writer, filter);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }

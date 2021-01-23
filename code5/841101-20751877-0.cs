    public void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement("bar");
        new XmlSerializer(typeof(Bar)).Serialize(writer, bar);
        writer.WriteEndElement();
    }

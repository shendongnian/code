    private DimensionInfo _value;
    public void WriteXml(XmlWriter writer)
    {
        var valueSerializer = new XmlSerializer(typeof (DimensionInfo));
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        writer.WriteStartElement("entry");
        writer.WriteAttributeString("key", string.Empty, string.Empty);
        // Here you define how you want your XML structure to look like
        // E.g. write an empty XML node in case of a null value
        if (_value != null) 
        {
            valueSerializer.Serialize(writer, value, ns);
        }
        writer.WriteEndElement();
    }

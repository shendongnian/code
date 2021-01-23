    private static void CreateXmlDocument(XmlWriter writer)
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("Product");
        writer.WriteAttributeString("ID", "001");
        writer.WriteAttributeString("Name", "Soap");
        writer.WriteElementString("Price", "10.00");
        writer.WriteStartElement("OtherDetails");
        writer.WriteElementString("BrandName", "X Soap");
        writer.WriteElementString("Manufacturer", "X Company");
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }

    private static XDocument CreateXmlFromObjects(string rootElementName, params object[] inputs)
    {
        var doc = new XDocument();
        using (XmlWriter writer = doc.CreateWriter())
        {
            writer.WriteStartElement(rootElementName);                
            foreach (var input in inputs)
                new XmlSerializer(input.GetType()).Serialize(writer, input);
            writer.WriteEndElement();
        }
                        
        return doc;
    }

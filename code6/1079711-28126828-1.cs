    string rootElement = null;
    
    using (XmlReader reader = XmlReader.Create(xmlFileName))
    {
        while (reader.Read())
        {
            // We won't have to read much of the file to find the root element as it will be the first one found
            if (reader.NodeType == XmlNodeType.Element)
            {
                rootElement = reader.Name;
                break;
            }
        }
    }

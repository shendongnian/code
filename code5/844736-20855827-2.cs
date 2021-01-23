        return result;
    }
    
    private static List<XmlTag> ParseXml(string path)
    {
        var result = new List<XmlTag>();
    
        using (var reader = XmlReader.Create(path))
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    result.AddRange(ParseElement(reader, new XmlTag() { XML_TAG = reader.Name }));
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    result.Add(new XmlTag() { XML_TAG = reader.Name });
                }
            }
        }
    
        return result;
    }

    private static List<XmlTag> ParseElement(XmlReader reader, XmlTag element)
    {
        var result = new List<XmlTag>() { element };
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    element.IsContainer = true;
                    result.AddRange(ParseElement(
                        reader,
                        new XmlTag() { XML_TAG = reader.Name }));
                    break;
                case XmlNodeType.Text:
                    element.XML_VALUE = reader.Value;
                    break;
                case XmlNodeType.EndElement:
                    return result;
                    break;
            }
        }
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
                    result.AddRange(ParseElement(
                        reader,
                        new XmlTag() { XML_TAG = reader.Name }));
                }
            }
        }
        return result;
    }

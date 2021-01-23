    private static List<XmlTag> ParseElement(XmlReader reader, XmlTag element)
    {
        var result = new List<XmlTag>() { element };
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    element.IsContainer = true;
                    var newTag = new XmlTag() { XML_TAG = reader.Name };
                    if (reader.IsEmptyElement)
                    {
                        result.Add(newTag);
                    }
                    else
                    {
                        result.AddRange(ParseElement(reader, newTag));
                    }
                    break;
                case XmlNodeType.Text:
                    element.XML_VALUE = reader.Value;
                    break;
                case XmlNodeType.EndElement:
                    if (reader.Name == element.XML_TAG)
                    {
                        result.Add(new XmlTag()
                            {
                                XML_TAG = string.Format("/{0}", reader.Name),
                                IsContainer = element.IsContainer
                            });
                    }
                    return result;
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
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    result.Add(new XmlTag() 
                        { 
                            XML_TAG = string.Format("/{0}",current.Name)
                        });
                }
            }
        }
    
        return result;
    }

    static IEnumerable<XElement> StreamCustomerItem(string uri)
    {
        using (XmlReader reader = XmlReader.Create(uri))
        {
            XElement name = null;
            XElement item = null;
    
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            name = XElement.ReadFrom(reader) as XElement;
                            break;
                        }
                    }
                    
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.EndElement)
                            break;
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            item = XElement.ReadFrom(reader) as XElement;
                            if (item != null) 
    						{
                                XElement tempRoot = new XElement("Root", new XElement(name));
                                tempRoot.Add(item);
                                yield return item;
                            }
                        }
                    }
                }
            }
        }
    }

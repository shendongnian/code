                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "City")
                    {
                        total_population+= Convert.ToInt32(reader.GetAttribute(1));
                    }
                }
            }

    XmlReader reader = XmlReader.Create("Your_XML_Path");
    string id;
      while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Mailbox")
                    {
                        id = reader.GetAttribute(0);
                    }
                }
            }

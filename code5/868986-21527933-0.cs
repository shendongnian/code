        using (XmlReader reader = XmlReader.Create(new StringReader(xmlString), settings))
            {
                while (reader.ReadToFollowing("Client"))
                {
                    reader.ReadToFollowing("Name");
                    var message = reader.ReadElementContentAsString();
                    //advance to <Message> element
                    reader.ReadToFollowing("Messages");
                    
                    //create sub-tree reader to restrict the scope
                    var typeReader = reader.ReadSubtree();
                    while (typeReader.ReadToFollowing("Type"))
                    {
                        var value = reader.GetAttribute("value");
                        var name = reader.GetAttribute("name");
                    }//everything stops here///
                }
            }

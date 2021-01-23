        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ConformanceLevel = ConformanceLevel.Fragment;
        using (XmlReader reader = XmlReader.Create(tr,settings))
        {
                   while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
    // this is from my code. You'll rewrite this part :
                            case XmlNodeType.Element:
                                if (t != null)
                                {
                                    t.SetName(reader.Name);
                                }
                                else if (reader.Name == "event")
                                {
                                    t = new Event1();
                                    t.Name = reader.Name;
                                }
                                else if (reader.Name == "data")
                                {
                                    t = new Data1();
                                    t.Name = reader.Name;
                                }
                                else
                                {
                                    throw new Exception("");
                                }
                                break;
                            case XmlNodeType.Text:
                                if (t != null)
                                {
                                    t.SetValue(reader.Value);
                                }
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                break;
                            case XmlNodeType.Comment:
                                break;
                            case XmlNodeType.EndElement:
                                if (t != null)
                                {
                                    if (t.Name == reader.Name)
                                    {
                                        t.Close();
                                        t.Write(output);
                                        t = null;
                                    }
                                }
                                break;
                            case XmlNodeType.Whitespace:
                                break;
                        }
                    }
        }

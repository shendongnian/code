        using (XmlWriter x = XmlWriter.Create(filename)) {
                // Create XML document
                #region dont-format-this     // <-- Any way to get VS to recognize something like this?
                x.WriteStartDocument();
                {
                    x.WriteStartElement("RootElement");
                    {
                        x.WriteStartElement("ChildElement1");
                        {
                            x.WriteStartElement("GrandchildElement1a");
                            {
                                x.WriteElementString("GreatGrandchildElement1a1");
                                x.WriteElementString("GreatGrandchildElement1a2");
                            }
                            x.WriteEndElement();
                            x.WriteElementString("GrandchildElement1b");
                        }
                        x.WriteEndElement();
                    }
                    x.WriteStartElement("ChildElement2");
                    x.WriteEndElement();
                }
                x.WriteEndElement();
                x.WriteEndDocument();
            }
            #endregion
        }

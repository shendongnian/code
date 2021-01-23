                        System.Xml.XmlDocument myXmlDocument = new System.Xml.XmlDocument();
                        myXmlDocument.Load("myFullPathWebConfig.xml");
                        foreach (System.Xml.XmlNode node in myXmlDocument["configuration"]["connectionStrings"])
                        {
                            if (node.Name == "add")
                            {
                                if (node.Attributes.GetNamedItem("name").Value == "SCI2ConnectionString")
                                {
                                    node.Attributes.GetNamedItem("connectionString").Value = connectionString;
                                }
                            }
                        }

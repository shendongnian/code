                String st = "Your Xml";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(st);
                XmlReader read = XmlReader.Create(new StringReader(st));
                string Xml = "<doc>";
                while (read.Read())
                {
                    if (read.AttributeCount > 0)
                    {
                        for (int i = 0; i < read.AttributeCount; i++)
                        {
                            if (read.Name == "xml" || read.Name.Split(':').Count() < 2)
                                break;
                            var node = doc.GetElementsByTagName(read.Name);
                            Xml += "<field name=\"" + node[0].Attributes[i].Name + "\">" + node[0].Attributes[i].Value + "</field>";
                        }
                    }
                    else
                    {
                        if (read.Name != string.Empty && read.Name.Split(':').Count() > 1)
                            Xml += "<field name=\"" + read.LocalName + "\">" + read.ReadInnerXml() + "</field>";
                    }
                }
                Xml += "</doc>";

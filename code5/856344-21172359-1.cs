            private Hashtable getSettings(string path)
            {
                Hashtable _ret = new Hashtable();
                if (File.Exists(path))
                {
                    StreamReader reader = new StreamReader
                    (
                        new FileStream(
                            path,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.Read)
                    );
                    XmlDocument doc = new XmlDocument();
                    string xmlIn = reader.ReadToEnd();
                    reader.Close();
                    doc.LoadXml(xmlIn);
                    foreach (XmlNode child in doc.ChildNodes)
                        if (child.Name.Equals("Settings"))
                            foreach (XmlNode node in child.ChildNodes)
                                if (node.Name.Equals("add"))
                                    _ret.Add
                                    (
                                        node.Attributes["key"].Value,
                                        node.Attributes["value"].Value
                                    );
                }
                return (_ret);
            }

    XmlDocument doc = new XmlDocument();
                string str = "<config><app version=" + "\"1.1.0\"" + "/></config>";
                doc.LoadXml(str);
                var node = doc.SelectSingleNode("//app");
                    if (node.Attributes["version"] != null)
                    {
                        string version = node.Attributes["version"].Value;
                        Console.WriteLine(version);
                    }
                  

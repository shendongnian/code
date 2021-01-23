    string text = System.IO.File.ReadAllText(@"XMLFile.XML");
    
                XmlDocument currentDocument = new XmlDocument();
                try
                {
                    currentDocument.LoadXml(text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    
                string path = "//*"; // retieve all data
                XmlNodeList nodeList = currentDocument.SelectNodes(path);
                IDictionary<string, string> keyValuePairList = new Dictionary<string, string>();
                foreach (XmlNode node in nodeList)
                {
                    foreach (XmlNode innerNode in node.ChildNodes)
                    {
                        if (innerNode.Attributes != null && innerNode.Attributes.Count == 2)
                        {
                            keyValuePairList.Add(new KeyValuePair<string, string>(innerNode.Attributes[0].Value, innerNode.Attributes[1].Value));
                        }
                    }
                }
                foreach (KeyValuePair<string, string> pair in keyValuePairList)
                {
                    Console.WriteLine(string.Format("{0} : {1}", pair.Key, pair.Value));
                }
                Console.ReadLine();

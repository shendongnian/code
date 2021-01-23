    private string getResponse(string questionID)
                {
                    string response = string.Empty;
                    using (StreamReader sr = new StreamReader("QuestionXML.xml", true))
                    {
                        XmlDocument xmlDoc1 = new XmlDocument();
                        xmlDoc1.Load(sr);
                        XmlNodeList itemNodes = xmlDoc1.GetElementsByTagName("question");
                        if (itemNodes.Count > 0)
                        {
                            foreach (XmlElement node in itemNodes)
                            {
                                if (node.Attributes["id"].Value.ToString() == questionID.Trim())
                                {
                                    response = node.SelectSingleNode("response").InnerText;
                                    break;
                                }
        
                            }
                        }
                    }
                    return response;
                }

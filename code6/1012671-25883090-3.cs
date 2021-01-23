            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(filename);
            XmlNodeList elemList = xmlDoc.GetElementsByTagName("add");
            for (int i = 0; i < elemList.Count; i++)
            {
                string keyname = elemList[i].Attributes["key"].Value;
                string keyvalue = elemList[i].Attributes["value"].Value;
                if (!keyname.EndsWith("Ctrl"))
                {
                    for(int j = 0 ; j < elemList.Count; j++)
                    {
                        bool xmlnode = elemList[j].Attributes["key"]
                                       .Value.Equals(keyname + "Ctrl");
                        if (xmlnode)
                        {
                            string value2 = elemList[j].Attributes["value"].Value;
                        }
                    }
                }
            }

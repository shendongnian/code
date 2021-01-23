        public Dictionary<string, string> GetDataFromSettings(TextReader reader, string xmlFilePath, string strValues)
        {
            Dictionary<string, string> dictValus = new Dictionary<string, string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(reader);
            if (!(xmlDoc == null))
            {
                string[] splitValues = strValues.Split(new char[] { ',' });
                if (splitValues.Length > 1)
                {
                    foreach (string strName in splitValues.Select((s) => s.Trim()))
                    {
                        Dictionary<string, string> strDictValues = new Dictionary<string, string>();
                        if (HttpRuntime.Cache[strName] == null)
                        {
                            XmlNodeList xmlList = xmlDoc.SelectNodes("Settings/Test1/" + strName);
                            foreach (XmlNode node in xmlList)
                            {
                                if (node.FirstChild.Name.ToString() != node.LastChild.Name.ToString())
                                {
                                    foreach (XmlNode childNode in node.ChildNodes)
                                    {
                                        strDictValues.Add(strName + "." + childNode.LocalName, childNode.InnerText);
                                    }
                                }
                                else
                                {
                                    strDictValues.Add(strName + "." + node.FirstChild.LocalName, node.InnerText);
                                }
                            }
                            HttpRuntime.Cache.Insert(strName, strDictValues, new System.Web.Caching.CacheDependency(xmlFilePath));
                        }
                        else
                        {
                            var tmpDict = (Dictionary<string, string>)HttpRuntime.Cache[strName];
                            foreach (var tmpVal in tmpDict)
                            {
                                strDictValues.Add(tmpVal.Key, tmpVal.Value);
                            }
                        }
                        foreach (var tmpStrDict in strDictValues)
                        {
                            dictValus.Add(tmpStrDict.Key, tmpStrDict.Value);
                        }
                    }
                }
            }
            return dictValus;
        }

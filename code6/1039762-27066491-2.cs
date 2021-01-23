        public static string GetSummary(this ApiDescription description, string language)
        {
            string output = string.Empty;
            var summaries = description.Documentation;
            if (!string.IsNullOrEmpty(summaries))
            {
                var xmlDocument = new System.Xml.XmlDocument();
                xmlDocument.LoadXml(summaries);
                var xmlNodeList = xmlDocument.GetElementsByTagName("summary");
                if (xmlNodeList.Count > 0)
                {
                    output = xmlNodeList[0].InnerText;
                    for (int i = 0; i < xmlNodeList.Count; i++)
                    {
                        var attribute = xmlNodeList[i].Attributes["xml:lang"];
                        if (attribute!= null && attribute.InnerText == language)
                        {
                            output = xmlNodeList[i].InnerText;
                        }
                    }
                }
            }
    
            return output;
        }

        public List<string> GetListOfData()
        {
            XmlDocument xmlDOC = new XmlDocument();
            
            xmlDOC.LoadXml("<Html><value periodid='Yabba'>YabbaValue</value><value periodid='Dabba'>DabbaValue</value><value periodid='Doo'>DooValue</value></Html>"); // string storing my XML 
            
            var value = xmlDOC.GetElementsByTagName("value");
            var listOfStrings = new List<string>();
            for (int i = 0; i < value.Count; i++)
            {
                var xmlAttributeCollection = value[i].Attributes;
                
                if (xmlAttributeCollection != null)
                {
                    var action = xmlAttributeCollection["periodid"];
                    string Period1 = action.Value;
                    listOfStrings.Add(QPR_webService_Client.GetAttributeAsString(sessionId, Period1, "name", ""));
                }
            }
            return listOfStrings;
        }

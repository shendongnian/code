    public static string[] elementStartWeek()
        {
            XmlDocument xmldoc = new XmlDocument();
    
            fileExistsWeek(xmldoc);
    
            XmlNodeList nodeStart = xmldoc.GetElementsByTagName("Start");
    
            int count2 = 0;
            string[] starttxtWeek = new string[nodeStart.Count];
    
                for (int i = 0; i < nodeStart.Count; i++)
                {
                    starttxtWeek[i] = nodeStart[i].InnerText;
                    count2++;
                }
    
            return starttxtWeek;
        }

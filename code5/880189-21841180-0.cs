      public static List<XmlValue> GetAllOrg()
        {
            XmlDocument document = new XmlDocument();
            document.Load(strXmlPath);
            XmlNodeList nodeList = document.SelectNodes("Organizations/Organization");
            List<XmlValue > list = new List<XmlValue >();
            foreach (XmlNode node in nodeList)
            {
                list.Add(new XmnValue(){
                value = node.Attributes["name"].Value,
                name = node.Attributes["name"].Name
                     });
             }
        return list;
    }    

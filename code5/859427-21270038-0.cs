    public void ParseXML(string XMLPath)
        {
            XmlReader xmlReader = XmlReader.Create(XMLPath);
            while (xmlReader.Read())
            {
                if (xmlReader.Name.Equals("FileLocation") && (xmlReader.NodeType == XmlNodeType.Element))
                {
                    string url = xmlReader.GetAttribute("Url");
                }
            }
          
        }

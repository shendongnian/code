    public string StringXmltoJSon(string xmlDoc)
    {
         XmlDocument I_xDoc = new XmlDocument();
         I_xDoc.LoadXml(xmlDoc);
         string jsonText = JsonConvert.SerializeXmlNode(I_xDoc);
         return jsonText;
    }

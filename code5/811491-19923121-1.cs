    public void LoadXML()
    {
        string sSiteMapFilePath = HttpRuntime.AppDomainAppPath + "sitemap_index.xml";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(HttpRuntime.AppDomainAppPath + "sitemap_index.xml");
        XmlNode node=GenerateIndexNode(xmlDoc);
        XmlNode childNode = xmlDoc.DocumentElement;
        childNode.InsertAfter(node, childNode.LastChild);
        xmlDoc.Save(sSiteMapFilePath);
    }

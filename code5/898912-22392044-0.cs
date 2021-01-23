    void myMethod()
    {
        var example = String.Empty;  // Unnecessary initialization
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml("c:\my.xml");
        example = doc.SelectSingleNode("//TestNode").OuterXml;
    }

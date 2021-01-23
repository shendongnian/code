    var nsmgr = new XmlNamespaceManager(doc.NameTable);
    nsmgr.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
    var SNameNodes = doc.SelectNodes("/wsdl:definitions/wsdl:service", nsmgr);
    foreach (XmlNode node in SNameNodes)
    {
        System.Console.WriteLine("The service name is " + node.Attributes["name"].Value);
    }

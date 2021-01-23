    XmlDocument doc = new XmlDocument();
    doc.Load("XMLFile1.xml");
    // Give the namespace an alias that we will use in our XPath statement
    XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
    mgr.AddNamespace("a", "http://Microsoft.EnterpriseManagement.Core.Criteria/");
    // Find any Criteria node tagged with the "a" namespace
    XmlNode node = doc.SelectSingleNode("//a:Criteria", mgr);
    Console.WriteLine(node.OuterXml);

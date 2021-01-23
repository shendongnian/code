    var doc = new XmlDocument();
    doc.Load("example.xml");
    XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
    ns.AddNamespace("anyname", "http://tempuri.org/zitem.xsd");
    foreach (XmlNode node in doc.SelectNodes("//anyname:ITEM", ns))
    {
        Console.WriteLine(node.Attributes["id"].Value);
    }

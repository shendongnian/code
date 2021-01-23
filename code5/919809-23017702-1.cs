    using System.Xml.XPath;
    var document = XDocument.Load(fileName);
    var namespaceManager = new XmlNamespaceManager(new NameTable());
    namespaceManager.AddNamespace("a", "http://schemas.datacontract.org/2004/07/Test.DataContracts.Global");
    var name = document.XPathSelectElement("path", namespaceManager).Value;

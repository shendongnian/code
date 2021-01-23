    using System.Xml.XPath;
      
    var document = System.Xml.Linq.XDocument.Load(@"D:\test.xml");
    var namespaceManager = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
    namespaceManager.AddNamespace("my", "http://schemas.microsoft.com/office/infopath/2003/myXSD/2013-01-09T15:23:27");
    namespaceManager.AddNamespace("html", "http://www.w3.org/1999/xhtml");
    var pValue = document.XPathSelectElement("/my:myFields/my:ProjectDescription/html:html/html:p", namespaceManager).Value;

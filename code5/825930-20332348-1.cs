    public string GetErrorMessage(string xml)
    {
        using (StringReader sr = new StringReader(xml))
        {
            var doc = new XPathDocument(sr);
            var nav = doc.CreateNavigator();
            var xmlNs = new XmlNamespaceManager(nav.NameTable);
            xmlNs.AddNamespace("env", @"http://www.w3.org/2003/05/soap-envelope");
            var node = nav.SelectSingleNode("//env:Text", xmlNs);
            return node.Value;
        }
    }

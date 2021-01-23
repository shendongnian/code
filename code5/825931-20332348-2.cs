    public string GetErrorMessage(string xml)
    {
        var doc = XDocument.Parse(xml);
        var node = doc.Descendants(XName.Get("Text", @"http://www.w3.org/2003/05/soap-envelope"))
                      .FirstOrDefault();
        return node.Value;
    }

    XDocument xDoc = XDocument.Load(file);
    XNamespace ns = XNamespace.Get("http://www.w3.org/1999/xhtml");
    var cas = xDoc.Descendants().First(e => e.Name.Equals(ns.GetName("case")));
    foreach (var row in cas.Elements())
    {
        var columnVals = row.Elements(ns.GetName("inner")).Select(e => e.Nodes());
        var str = columnVals.Skip(1).First();
        var stringResult = WebUtility.HtmlDecode(string.Join(" ", str));
    }

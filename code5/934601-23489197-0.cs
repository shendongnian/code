    var doc = XDocument.Parse(Xml);
    var ns1 = XNamespace.Get("http://TheNamespaceMappedToTheNs1Prefix");
    var elements = doc.Descendants(ns1 + "AcctId");
    foreach (var e in elements)
    {
        e.Value = IBANHelper.ConvertBBANToIBAN(e.Value); 
    }
    Xml = doc.ToString();

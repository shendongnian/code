    XNamespace ns = "http://webservices.whitespacews.com/";
    ...
    var test = xmlDoc.Descendants(ns + "Collection")
                     .Select(x => new
                     {
                         day = x.Element(ns + "Day").Value,
                         date = x.Element(ns + "Date").Value
                     });

    var query = root.Descendants(aw + "Data")
                    .Where(x => (string)x.Attribute(kw + "type") == "green")
                    .Elements(ns + "Document")
                    .Elements(ns + "Country")
                    .Select(x => x.Value);
    foreach (var item in query)
    {
        Console.WriteLine(item);
    }

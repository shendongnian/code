    var xDoc = XDocument.Parse(xmlstr);
    var list = xDoc.Descendants()
               .Select(x=>new{
                   Name =  x.Name.LocalName,
                   Namespace = x.Name.Namespace.ToString(),
                   Attributes =  x.Attributes().ToDictionary(a=>a.Name.LocalName, a=>a.Value),
                   Value = x.HasElements ? "" :  x.Value
                })
               .ToList();

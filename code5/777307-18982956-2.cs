    XDocument doc=XDocument.Load(stream);
    var pList=doc.Descendants()
                       .Elements(x=>x.Name.LocalName=="class")
                       .Select(a=>
                             new
                             {
                                className=a.Attribute("className").Value,
                                p=a.Attribute("p").Value
                             });

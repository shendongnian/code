    XDocument doc = XDocument.Parse(x);
    var res = doc.Descendants("CENTER")
                 .Where(el => el.Elements("ID").Count() > 0 && el.Elements("CENTER").Count() > 0)
                 .Select(el => new { 
                                     id = el.Element("ID").Value,
                                     center = el.Element("CENTER").Value 
                                   })
                 .ToList();

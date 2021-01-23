    XDocument xdoc = XDocument.Load(Server.MapPath("Content/Doc.xml"));
    
    var newsParent = xdoc.Descendants("news").First();  // gets the parent news item
    var news = newsParent.Descendants("news")
        .Select(x => new {Name = x.Attribute("name"), Date = x.Attribute("date")});
    foreach (var element in news)
    {
        Console.WriteLine(element.Name +" "+ element.Date);
    }

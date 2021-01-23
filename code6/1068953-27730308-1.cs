    XNamespace ns = "http://www.w3.org/2005/Atom";
    var item = document.Descendants(ns + "entry")
                       .Select(entry => new NewsItem
                               {
                                   link = entry.Element(ns + "link")
                                               .Attribute("href").Value,
                                   description = entry.Element(ns + "summary").Value,
                                   title = entry.Element(ns + "title").Value,
                                   image = " "
                                   entry_date = DateTime.Now,
                                   category = " "
                               })
                       .ToList();

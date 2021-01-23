    HtmlAgilityPack.HtmlDocument doc;
    var web = new HtmlAgilityPack.HtmlWeb();
    doc = web.Load("urlwebsite");
    
    var itemList = doc.DocumentNode.SelectNodes("//p")
                      .Select(p => p.InnerText)
                      .ToList();

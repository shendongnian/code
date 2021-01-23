    var html = WebUtility.HtmlDecode(yourtext);
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var urls = doc.DocumentNode.SelectNodes("//img[@src]")
                  .Select(img => img.Attributes["src"].Value)
                  .ToList(); 

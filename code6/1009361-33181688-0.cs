    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(html);
    
    var oldHtml = doc.DocumentNode.InnerHtml;
    
    if (doc.DocumentNode.SelectNodes("//img[@usemap]") != null)
    {
        HtmlNode img = doc.DocumentNode.SelectSingleNode("//img[@usemap]");
        img.ParentNode.RemoveChild(img);
    }
    
    if (doc.DocumentNode.SelectNodes("//map") != null)
    {
        HtmlNode map = doc.DocumentNode.SelectSingleNode("//map");
        map.ParentNode.RemoveChild(map);
    }
    
    var newHtml = doc.DocumentNode.InnerHtml;

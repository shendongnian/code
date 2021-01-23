    foreach (var p in doc.DocumentNode.SelectNodes("//p"))
    {
        p.ParentNode.ReplaceChild(
               HtmlAgilityPack.HtmlNode.CreateNode("<div>" + p.InnerHtml + "</div>"), 
               p);
    }
    foreach (var b in doc.DocumentNode.SelectNodes("//b"))
    {
        b.ParentNode.ReplaceChild(
                HtmlAgilityPack.HtmlNode.CreateNode("<strong>" + b.InnerHtml + "</strong>"), 
        b);
    }

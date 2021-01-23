    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var comments = doc.DocumentNode
                    .Descendants()
                    .Where(d => d.Name != "script" && d.Name != "style")
                    .Where(d=>d.Name=="#comment")
                    .Select(d=>d.InnerText)
                    .ToList();

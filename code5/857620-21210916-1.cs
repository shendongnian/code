    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(orghtml);
    var brs = doc.DocumentNode.SelectNodes("//span/br"); //all br's in span's
    foreach(var br in brs )
    {
        var span = br.ParentNode;
        span.ParentNode.InsertAfter(HtmlAgilityPack.HtmlNode.CreateNode("<br>"), span);
        br.Remove();
    }
    var newhtml = doc.DocumentNode.OuterHtml;

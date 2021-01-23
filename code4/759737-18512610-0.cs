    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load(fname);
    var comments = doc.DocumentNode.SelectNodes("//comment()")
                    .Select(n => n.InnerText)
                    .ToList();

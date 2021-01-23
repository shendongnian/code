    var html = "<ul><li><p>LARGE</p><p>Lamb</p><br></li></ul>&nbsp;";
    var hap = new HtmlDocument();
    hap.LoadHtml(html);
    string text = HtmlEntity.DeEntitize(hap.DocumentNode.InnerText);
    // text is now "LARGELamb "
    string[] lines = hap.DocumentNode.SelectNodes("//text()")
        .Select(h => HtmlEntity.DeEntitize(h.InnerText)).ToArray();
    // lines is { "LARGE", "Lamb", " " }
    

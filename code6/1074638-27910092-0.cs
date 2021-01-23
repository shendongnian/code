    var html = "<ul><li><p>LARGE</p> <p>Lamb</p><br></li></ul>&nbsp;";
    var hap = new HtmlDocument();
    hap.LoadHtml(html);
    string text = HtmlEntity.DeEntitize(hap.DocumentNode.InnerText);
    // text is now "LARGE Lamb "
    string[] lines = hap.DocumentNode.SelectNodes("//p").Select(h => h.InnerText).ToArray();
    // lines is { "LARGE", "Lamb" }
    

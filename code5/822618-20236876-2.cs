    HtmlDocument hdoc = new HtmlDocument();
    hdoc.LoadHtml(xmlstring);
    var tags = hdoc.DocumentNode.Descendants()
                   .Select(r => r.GetAttributeValue("ows_Article_x0020_Tags", ""));
    string result = String.Join("", tags);
    // 14;#cricket;#21;#Headlines;#19;#Videos20;#Charity;#14;#cricket

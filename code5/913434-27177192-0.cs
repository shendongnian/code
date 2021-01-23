    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(webBrowser1.DocumentText);
            
    foreach (HtmlAgilityPack.HtmlNode node in doc.DocumentNode.ChildNodes) {
        node.Attributes.Add("TEST", "TEST");
    }
    StringBuilder sb = new StringBuilder();
    using (StringWriter sw = new StringWriter(sb)) {
        doc.Save(sw);
        webBrowser1.DocumentText = sb.ToString();
    }

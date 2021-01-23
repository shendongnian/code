    public string StripTags(string input) {
        var doc = new HtmlDocument();
        doc.LoadHtml(input ?? "");
        return doc.DocumentNode.InnerText;
    }

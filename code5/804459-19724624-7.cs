    private List<string> GetLinks()
    {
        var links = new List<string>();
        HtmlDocument doc = new HtmlDocument();
        doc.Load("");
        foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            HtmlAttribute attribute = link.Attributes["href"];
            if (attribute != null)
            {
                links.Add(attribute.Value);
            }
        }
        return links;
    }

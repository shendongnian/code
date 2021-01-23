    private static void addPerson(string websiteUrl)
    {
        var p = new Program();
        dict.Add(websiteUrl, new WebsiteInfo { WebsiteUrl = websiteUrl, HtmlCode = p.getHtml(websiteUrl) });
    }

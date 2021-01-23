    static public List<string> GetTdTitles(string htmlCode, string TdSearchPattern)
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(htmlCode);
        HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//td[@" + TdSearchPattern + "]");
        List<string> Results = new List<string>();
        foreach (HtmlNode node in collection)
        {
            Results.Add(node.InnerText);
        }
         
        return Results;
    }

    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(htmlCode);
    foreach (HtmlNode row in doc2.DocumentNode.SelectNodes("//td[@class='title'][(normalize-space(.)='00-01')]/ancestor::table"))
    {
        foreach (var cell in row.SelectNodes("./tr/td"))
        {
            if (string.IsNullOrEmpty(cell.InnerText.Trim()))
                continue;
            Console.WriteLine(cell.InnerText.Trim());
        }
    }

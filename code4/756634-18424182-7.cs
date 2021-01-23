    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(htmlCode);
    foreach (HtmlNode row in doc.DocumentNode.SelectNodes("//td[@class='title']"))
    {
        if (row.InnerText.Trim() == "00-01")
        {
            foreach (var cell in row.ParentNode.ChildNodes)
            {
                if (string.IsNullOrEmpty(cell.InnerText.Trim()))
                    continue;
                Console.WriteLine(cell.InnerText.Trim());
            }
        }
    }

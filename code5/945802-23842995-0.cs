    HtmlNodeCollection innerDivs = document.DocumentNode.SelectNodes("//div/div");
    foreach (HtmlNode div in innerDivs)
    {
        HtmlNodeCollection spans = link.SelectNodes("span");
        foreach(HtmlNode span in spans)
        {
            string text = span.InnerText;
        }
    }

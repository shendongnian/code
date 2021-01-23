    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    // There are various options, set as needed
    htmlDoc.OptionFixNestedTags = true;
    htmlDoc.Load(@"C:\Platypus\dplatypus.htm");
    if (htmlDoc.DocumentNode != null)
    {
        IEnumerable<HtmlAgilityPack.HtmlNode> textNodes = htmlDoc.DocumentNode.SelectNodes("//text()");
        foreach (HtmlNode node in textNodes)
        {
            if (!string.IsNullOrWhiteSpace(node.InnerText))
            {
                MessageBox.Show(node.InnerText);
            }
        }
    }

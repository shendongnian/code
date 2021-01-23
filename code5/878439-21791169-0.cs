    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    // There are various options, set as needed
    htmlDoc.OptionFixNestedTags = true;
    htmlDoc.Load(@"C:\Platypus\dplatypus.htm");
    if (htmlDoc.DocumentNode != null)
    {
        IEnumerable<HtmlAgilityPack.HtmlNode> pNodes = htmlDoc.DocumentNode.SelectNodes("//p");
        foreach (HtmlNode node in pNodes)
        {
                MessageBox.Show(node.InnerText);
        }
    }

    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class='" + ClassToGet + "']"))
    {
        string value = node.InnerText;
        // etc...
    }

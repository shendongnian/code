    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='result-link']");
    if (nodes != null)
    {
        foreach (HtmlNode node in nodes)
        {
            HtmlNode a = node.SelectSingleNode("a[@href]");
            if (a != null)
            {
                // use  a.Attributes["href"];
            }
            // etc...
        }
    }

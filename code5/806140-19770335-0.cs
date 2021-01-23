    HtmlDocument doc = new HtmlDocument();
    doc.Load("index.html");
    var spans = doc.DocumentNode.SelectNodes("//span[contains(., '(x)')]");
    foreach (var span in spans)
    {
        HtmlNode parent = span.ParentNode;
        while (parent != null)
        {
            if (parent.Name == "div")
            {
                parent.Remove();
                break;
            }
            parent = parent.ParentNode;
        }
    }

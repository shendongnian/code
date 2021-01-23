    HtmlAgilityPack.HtmlDocument AgilePack = new HtmlAgilityPack.HtmlDocument();
    
    AgilePack.LoadHtml(ThisDocument.Body.OuterHtml);
    
    HtmlNodeCollection Nodes = AgilePack.DocumentNode.SelectNodes(@"//*");
    
    foreach (HtmlAgilityPack.HtmlNode Node in Nodes)
    {
        if (Node.Attributes["class"] != null)
            MessageBox.Show(Node.Attributes["class"].Value);
    
    }

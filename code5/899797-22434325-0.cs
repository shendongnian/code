    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    htmlDoc.LoadHtml(webBrowser1.Document.Body.InnerHtml);
    foreach (var elm in htmlDoc.DocumentNode.Descendants())
    {
        if (elm.NodeType == HtmlNodeType.Text)
        {
            //simple text is #text
            var innerText=elm.InnerText;
        }  
    }

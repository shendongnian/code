    HtmlElementCollection links = webBrowser.Document.GetElementsByTagName("A");
    
    foreach (HtmlElement link in links)
    {
        if (link.InnerText.Equals("This is Two"))
            link.InvokeMember("Click");
    }

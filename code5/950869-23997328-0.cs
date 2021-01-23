    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        var item = webBrowser1.Document.GetElementsByTagName("span");
        foreach(HtmlElement ht in item)
        {
            dynamic element = ht.DomElement;
            MessageBox.Show(element.Attributes["class"].Value.ToString());
        }
    }

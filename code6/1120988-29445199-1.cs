    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        button1.Enabled = true;
        textBox1.Enabled = true;
        var linkElements = Browser.Document.GetElementsByTagName("a");
        foreach(HtmlElement link in linkElements)
        {
            link.Click += (s, args) =>
            {
                // a link is being clicked
                // get the url the link is pointing to using the href attribute of the element
                textBox1.Text = link.GetAttribute("href");
            }
        }
    }

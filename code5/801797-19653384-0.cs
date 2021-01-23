    WebBrowser wb;
    private void Form1_Load(object sender, EventArgs e)
    {
        wb = new WebBrowser();
        wb.DocumentCompleted += wb_DocumentCompleted;
        wb.DocumentText = "<html><body><a href='#'>Test</a></body></html>";
    }
    void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        HtmlElementCollection elems = ((WebBrowser)sender)
            .Document.GetElementsByTagName("a");
        foreach (HtmlElement elem in elems)
        {
            // Do Some Stuff
        }
    }

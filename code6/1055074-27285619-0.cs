    public string NewDocumentTextForMeToPlayWith{ get; set; }
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        NewDocumentTextForMeToPlayWith = webBrowser1.DocumentText;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        HtmlElement theform = webBrowser1.Document.GetElementsByTagName("form")[0];
        theform.InvokeMember("Submit");
        while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
        {
            Application.DoEvents();
        }
        Thread.Sleep(1000);
    }

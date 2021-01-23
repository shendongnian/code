    public Form1()
    {
        InitializeComponent();
        string url = "http://www.google.com";
        wb.Navigate(url);  
    }
    TreeView tv = new TreeView();
    private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser wb = (WebBrowser)sender;
        if (wb.ReadyState == WebBrowserReadyState.Complete)
            tv.Nodes.Add(LoadNode(wb.Document.Body));
    }
    private TreeNode LoadNode(HtmlElement htmlElm)
    {
        TreeNode tn = new TreeNode(htmlElm.TagName);
        for (int i = 0; i < htmlElm.Children.Count; i++)
            tn.Nodes.Add(LoadNode(htmlElm.Children[i]));
        return tn;
    }

    private string tocpage = "IDSBooktoc.html";
    private string outpage = "IDSBookout.html";
    
    private void Form1_Load(object sender, EventArgs e)
    {
        //load toc, only for parsing
        webBrowser2.Visible = false;
        webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser2_DocumentCompleted);
        webBrowser2.DocumentText = File.ReadAllText(tocpage);
    }
    
    void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        //Populate treeview
        foreach (HtmlElement ele in webBrowser2.Document.GetElementsByTagName("a"))
        {
            treeView1.Nodes.Add(ele.GetAttribute("href"), ele.InnerText);
        }
        //detach event
        webBrowser2.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(webBrowser2_DocumentCompleted);
        //change webbrowser2 source
        webBrowser2.DocumentText = File.ReadAllText(outpage);
    }
    
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        string selected = e.Node.Name; //IDSBookout.html#NCXGen0
        string bookmark = selected.Substring(selected.IndexOf("#") + 1);
        webBrowser2.Document.GetElementById(bookmark).ScrollIntoView(true);
        webBrowser2.Visible = true;
    }

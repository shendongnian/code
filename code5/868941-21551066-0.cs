    private string tocpage = "IDSBooktoc.html";
    private string outpage = "IDSBookout.html";
    
    private void Form1_Load(object sender, EventArgs e)
    {
        webBrowser3.DocumentText = File.ReadAllText(tocpage);
        webBrowser2.DocumentText = File.ReadAllText(outpage);
    
        webBrowser3.Navigating += new WebBrowserNavigatingEventHandler(webBrowser3_Navigating);
    }
    
    private void webBrowser3_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        e.Cancel = true;
    
        //scroll webbrowser2
        string bookmark = e.Url.Fragment.Replace("#", "");
        webBrowser2.Document.GetElementById(bookmark).ScrollIntoView(true);
    }

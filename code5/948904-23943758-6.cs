    private void cb_loadURL_Click(object sender, EventArgs e)
    {
        string s = GetDocumentText(tb_URL.Text);
        s = s.Replace("javascript:window.close()", "");
        webBrowser1.AllowNavigation = true;
        webBrowser1.DocumentText = s;
    }
    public string GetDocumentText(string s) 
    { 
        WebBrowser dummy = new WebBrowser(); //(*)
        dummy.Url = new Uri(s);
        return dummy.DocumentText;
    }

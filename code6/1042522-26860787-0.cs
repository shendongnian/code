    private void webBro_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        if (e.Url.ToString() != "about:blank")
        {
    		e.Cancel = true;
    		System.Diagnostics.Process.Start(e.Url.ToString());
        }
    }

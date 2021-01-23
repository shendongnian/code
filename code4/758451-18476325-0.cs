    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (InternetExplorer ie in new ShellWindows())
        {
            if (ie.LocationURL.ToString().IndexOf("tinymce") != -1)
            {
                IWebBrowserApp wb = (IWebBrowserApp)ie;
                wb.Document.Frames.Item[0].document.body.InnerHtml = "<p>Hello, World at </p> " + DateTime.Now.ToString();
            }
        }
    }

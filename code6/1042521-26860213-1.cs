        void Form_Load()
        {
            webBrowser1.DocumentText = "<html><body><a href=\"D:\\test.pdf\">Click Me!</a></body></html>";
            webBrowser1.Document.Click += Document_Click;
        }
        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            if (webBrowser1.Document.ActiveElement.TagName == "A")
            {
                System.Diagnostics.Process.Start(webBrowser1.Document.ActiveElement.GetAttribute("HREF"));
            }
            e.ReturnValue = false;
        }

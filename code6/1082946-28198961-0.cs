     private void button1_Click(object sender, EventArgs e)
            {
                LogIn("", "");
            }
    
            private void LogIn(string user, string pass)
            {
                       .
                       . 
                       . 
            }
    
            private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                WebBrowser browser = sender as WebBrowser;
                if (!browser.Url.AbsoluteUri.Contains("MyView"))
                {
                    browser.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
                    browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
                    browser.Document.InvokeScript("Redirect");
                    // browser.Document.Forms[0].InvokeMember("submit");
                }
                else
                {
                    int a = 1;
                }
            }

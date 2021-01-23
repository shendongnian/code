            string plainText= StripHTML(webBrowser1);// call this way-----
            public string StripHTML(WebBrowser webp)
            {
                try
                {
                    Clipboard.Clear();
                    webp.Document.ExecCommand("SelectAll", true, null);
                    webp.Document.ExecCommand("Copy", false, null);
                }
                catch (Exception ep)
                {
                    MessageBox.Show(ep.Message);
                }
                return Clipboard.GetText();            
            }

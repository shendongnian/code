    private void Form1_Load(object sender, EventArgs e)
            {
                //WebBrowser webBrowser1 = new WebBrowser();
                webBrowser1.Navigate("http://www.facebook.com");
                
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(loaded);
               
    
            }
    
            
            private void loaded(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var bro = sender as WebBrowser;
                var List = bro.Document.GetElementsByTagName("input");
    
                
    
                foreach (HtmlElement Item in List)
                {
                    String Value = Item.GetAttribute("value");
                    if(Value != null && Value == "Log In")
                    {
                        MessageBox.Show(Value);
    
                        bro.Document.GetElementById("email").SetAttribute("value", "Some Email");
                        bro.Document.GetElementById("pass").SetAttribute("value", "Some Pass");
    
                        Item.InvokeMember("click");
                        // avoid Repetition
                        bro.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(loaded);
                    }
                }
            }

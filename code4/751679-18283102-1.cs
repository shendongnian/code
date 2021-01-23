       public TestStuff()  
       {
            string testing = "test";
            webBrowser2.DocumentCompleted += ((WebBrowserDocumentCompletedEventArgs)delegate(object sender, EventArgs args)
            {
                 evHandler(sender, testing);
            });
            webBrowser2.Navigate("http://google.com");
        }
       public void evHandler(Object sender, string testing)
       { 
             MessageBox.Show(testing);
       }

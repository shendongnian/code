       public TestStuff()  
       {
            string testing = "test";
            webBrowser2.Navigate("http://google.com");
            webBrowser2.DocumentCompleted += ((EventHandler)delegate(object sender, EventArgs args)
            {
                 evHandler(sender, testing);
            });
        }
       public void evHandler(Object sender, string testing)
       { 
             MessageBox.Show(testing);
       }

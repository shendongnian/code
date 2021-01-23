        IWebBrowser WebBrowserForm; // Has the method Navigate(string address)
 
        public HistoryForm(IWebBrowser webBrowser)
        {
            this.WebBrowserForm = webBrowser;
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            GetHomePageURL();
            WebBrowserForm.Navigate(address);
        }

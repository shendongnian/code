        void webView_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.Uri.AbsoluteUri.Contains("finished.html"))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

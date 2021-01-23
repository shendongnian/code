    private void KliknijMnie_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            ProgressBarRequest.Visibility = System.Windows.Visibility.Visible;
            webClient.DownloadStringAsync(new Uri("http://graph.facebook.com/stackoverflow"));
        }
        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    var root1 = JsonConvert.DeserializeObject<RootObject>(e.Result);
                    this.DataContext = root1;
           }
        }
     }

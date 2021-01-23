        public void LoadData()
        {
            if( IsDataLoaded )
                this.Items.Clear();
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new System.Uri("http://questoons.com/"));                     
        }

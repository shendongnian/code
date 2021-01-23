       private WebClient webClient;
        public Example()
        {
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://datastore.unm.edu/events/events.xml", UriKind.Absolute));
        }
        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            XElement Xmlparse = XElement.Parse(e.Result);
        }

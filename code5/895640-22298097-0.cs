    private void GetFeed(string rss)
    {
        //register event handler first, then call the async method
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
        webClient.DownloadStringAsync(new System.Uri(rss)); 
    }

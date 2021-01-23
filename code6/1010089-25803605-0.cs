    public void getRankingList(string country,string type)
        {            
            WebClient client = new WebClient();
            client.AllowReadStreamBuffering = true;
            string url = "......";
            client.DownloadStringCompleted += (sender, args) => 
            getRankingResult(sender, args, "para");
            client.DownloadStringAsync(new Uri(url, UriKind.Absolute));
        }
    private void getRankingResult(object sender, DownloadStringCompletedEventArgs e, string Para)
    {
        // .....
    }

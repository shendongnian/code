    public byte[] GetFileViaHttp(string url)
    {
        using (WebClient client = new WebClient())
        {
            client.Headers.Add("User-Agent: Other");    
            return client.DownloadData(url);
        }
    }

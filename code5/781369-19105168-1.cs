    public Task<string> AuthenticatedGetData(string url, string token)
        {
            WebClient client = new WebClient();
            return client.DownloadStringTaskAsync(new Uri(url + "?oauth_token=" + token));
        }

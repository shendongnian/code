    public static Task<string> GetData(string url, string data)
    {
        UriBuilder fullUri = new UriBuilder(url);
        if (!string.IsNullOrEmpty(data))
            fullUri.Query = data;
        WebClient client = new WebClient();
        client.Credentials = CredentialCache.DefaultCredentials;//TODO update as needed
        return client.DownloadStringTaskAsync(fullUri.Uri);
    }

    public static Task<string> GetData2(string url, string data)
    {
        UriBuilder fullUri = new UriBuilder(url);
        if (!string.IsNullOrEmpty(data))
            fullUri.Query = data;
        WebClient client = new WebClient();
        client.Credentials = CredentialCache.DefaultCredentials;//TODO update as needed
        var tcs = new TaskCompletionSource<string>();
        client.DownloadStringCompleted += (s, args) =>
        {
            if (args.Error != null)
                tcs.TrySetException(args.Error);
            else if (args.Cancelled)
                tcs.TrySetCanceled();
            else
                tcs.TrySetResult(args.Result);
        };
        client.DownloadStringAsync(fullUri.Uri);
        return tcs.Task;
    }

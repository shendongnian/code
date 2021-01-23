    public Task<string> AuthenticatedGetData(string url, string token)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }            
            };
            client.DownloadStringAsync(new Uri(url + "?oauth_token=" + token));
            return tcs.Task;
        }

    public Task<HttpWebResponse> GetAsync(HttpWebRequest req)
    {
        var tcs = new TaskCompletionSource<HttpWebResponse>();
        req.BeginGetResponse(e =>
            {
                if(e.IsCompleted)
                    tcs.TrySetResult((HttpWebResponse)req.EndGetResponse(e));
            }, null);
        return tcs.Task;
    }

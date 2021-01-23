    public Task<T> FetchTask { get; private set; }
    public bool StartFetch()
    {
        if (FetchTask != null) return false;
        mCancellationTokenSource = new CancellationTokenSource();
        FetchTask = FetchAsync(request, mCancellationTokenSource.Token);
        return true;
    }
    public bool CancelFetch()
    {
        // send cancellation
        if (mCancellationTokenSource != null)
            mCancellationTokenSource.Cancel();
        FetchTask = null;
        return true;
    }
    private async Task<T> FetchAsync(LFHttpRequest request, CancellationToken cancellationToken)
    {
        var message = new HttpRequestMessage(request.Method, request.Uri);
        var response = await HttpClient.SendAsync(message, cancellationToken); 
        response.EnsureSuccessStatusCode();
        var ret = // Convert response.Content into T.
        return ret;
    }

    static Task<HttpWebResponse> GetResponseWithRetryAsync(string url, int retries)
    {
        if (retries < 0)
            throw new ArgumentOutOfRangeException();
    
        var request = WebRequest.Create(url);
    
        Func<Task<WebResponse>, Task<HttpWebResponse>> proceedToNextStep = null;
    
        Func<Task<HttpWebResponse>> doStep = () =>
        {
            return request.GetResponseTapAsync().ContinueWith(proceedToNextStep).Unwrap();
        };
    
        proceedToNextStep = (prevTask) =>
        {
            if (prevTask.IsCanceled)
                throw new TaskCanceledException();
    
            if (prevTask.IsFaulted && --retries > 0)
                return doStep();
     
            // throw if failed or return the result
            return Task.FromResult((HttpWebResponse)prevTask.Result);
        };
    
        return doStep();
    }

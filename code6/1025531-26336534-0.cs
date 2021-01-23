    static class HttpClientExtentions
    {
        public static Task<string> GetStringWithRetryAsync(this HttpClient client, string url, int retries)
        {
            var completion = new TaskCompletionSource<string>();
            var ex = new List<Exception>();
    
            Task<string> getString = client.GetStringAsync(url);
            Action<Task<string>> continueAction = null;
            continueAction = (t) =>
            {
                if (t.IsFaulted)
                {
                    ex.Add(t.Exception);
    
                    if (retries-- > 0)
                    {
                        getString = client.GetStringAsync(url);
                        getString.ContinueWith(continueAction);
                    }
                    else
                    {
                        completion.SetException(new AggregateException(ex));
                    }
                }
                else // assume success, you could also handle cancellation
                {
                    completion.SetResult(t.Result);
                }
    
            };
    
            getString.ContinueWith(continueAction);
    
            return completion.Task;
        }
    }

    public static Task<TResult> LogErrors<TResult>(this Task<TResult> self, ConcurrentBag<Exception> exceptions)
        {
            return self.ContinueWith(s =>
            {
                if (!s.IsFaulted)
                {
                    return s.Result;
                }
                exceptions.Add(s.Exception);
                return default(TResult);
            },
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously |
            TaskContinuationOptions.DenyChildAttach,
            TaskScheduler.Default);
        }

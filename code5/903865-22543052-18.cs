    // .NET 4.0 compatible
    public static Task<Empty> Convert(this Task @this)
    {
        var tcs = new TaskCompletionSource<Empty>();
        @this.ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                var ex = t.Exception;
                // there is always AggregateException.InnerException 
                tcs.SetException(
                    ex.InnerExceptions.Count != 1 ? ex : ex.InnerException);
            }
            else if (t.IsCanceled)
                tcs.SetCanceled();
            else 
                tcs.SetResult(Empty.Value);
        }, TaskContinuationOptions.ExecuteSynchronously);
        return tcs.Task;
    }

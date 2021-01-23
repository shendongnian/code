    public static Task<bool> TryParseIntAsync(string s, out Task<int> result)
    {
        var tcs = new TaskCompletionSource<int>();
        result = tcs.Task;
        return ParseIntAsync(s).ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                tcs.SetException(t.Exception.InnerException);
                return false;
            }
            tcs.SetResult(t.Result);
            return true;
        }, default, TaskContinuationOptions.None, TaskScheduler.Default);
    }

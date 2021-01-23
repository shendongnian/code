    public static Task Delay(TimeSpan timeout)
    {
        var tcs = new TaskCompletionSource<bool>();
        new System.Threading.Timer(_ => tcs.TrySetResult(true),
            null, (long)timeout.TotalMilliseconds, Timeout.Infinite);
        return tcs.Task;
    }

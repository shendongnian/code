    Task Delay(int interval)
    {
         var z = new TaskCompletionSource<object>();
         new Timer(_ => z.SetResult(null)).Change(interval, -1);
         return z.Task;
    }
 

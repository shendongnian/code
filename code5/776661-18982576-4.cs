    Task AsyncLoop() {
        return AsyncLoopTask().ContinueWith(t =>
            Counter.Value = t.Result,
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    Task<int> AsyncLoopTask() {
        var tcs = new TaskCompletionSource<int>();
        DoIteration(tcs);
        return tcs.Task;
    }
    void DoIteration(TaskCompletionSource<int> tcs) {
        LoadNextItem().ContinueWith(t => {
            if (t.Exception != null) {
                tcs.TrySetException(t.Exception.InnerException);
            } else if (t.Result.Contains("target")) {
                tcs.TrySetResult(t.Result.Length);
            } else {
                DoIteration(tcs);
            }});
    }

    private Task LongRunningTask = /* Something */;
    
    private void DoSomethingMore() { }
    
    public async Task IndependentlyCancelableSuccessorTask(
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var tcs = new TaskCompletionSource<bool>();
        using (cancellationToken.Register(() => tcs.TrySetCanceled()))
            await Task.WhenAny(LongRunningTask, tcs.Task);
    
        cancellationToken.ThrowIfCancellationRequested();
        DoSomethingMore();
    }

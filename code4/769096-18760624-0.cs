    public Task<OpResult> BlackBoxOperationAysnc() {
        var tcs = new TaskCompletionSource<TestResult>();
        const int timeoutMs = 20000;
        var ct = new CancellationTokenSource(timeoutMs);
        ct.Token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: false);
        blackBox.StartAsyncOp();
    
   
        EventHandler<EndOpEventArgs> eventHandler = (sender, args) => {
            ...
            tcs.TrySetResult(OpResult.BlarBlar);
        }
        blackBox.EndAsyncOpEvent += eventHandler;
        return tcs.Task;
    }

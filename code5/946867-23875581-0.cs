    public Task PauseTask( ) 
    { 
        _m.Cancel( );
        _t = new CancellationTokenSource( int.MaxValue );
        // Make a task yourself
        var task = new TaskCompletionSource<bool>();
        _t.Token.Register(() => task.TrySetResult(true)); // Mark the task done
        return task.Task;
    }

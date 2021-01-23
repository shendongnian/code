    public async Task Start(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            // ...
            // ...
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            // ...
            // ...
            // How do I manage this additional task?
            args.Completed += (s, e) => { 
                tcs.SetResult( null ); // any value will do
            };
            this.socket.AcceptAsync(args);
            await tcs.Task;
        }
    }

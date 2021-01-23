    public static Task<MyCallCompletedEventArts> CallAsync(
        this MyAsyncServiceClient1 client)
    {
        var tcs = new TaskCompletionSource<MyCallCompletedEventArts>();
        EventHandler<MyCallCompletedEventArts> handler = null;
        handler = (_, args) =>
        {
            tcs.TrySetResult(args);
            client.MyCallCompleted -= handler;
        };
        client.MyCallCompleted += handler;
        client.MyCall();
        return tcs.Task;
    }

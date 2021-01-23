    public Task<IApiData> FetchQueuedApiAsync(TimeSpan receiveTimeout)
    {
        var tcs = new TaskCompletionSource<IApiData>();
        ReadQueue.BeginReceive(receiveTimeout);
        ReadQueue.ReceiveCompleted += (sender, args) =>
        {
            if (timedOut)
                tcs.TrySetCanceled();
            else if (threwException)
                tcs.TrySetException(exception);
            else
                tcs.TrySetResult(ReadQueue.EndReceive() as IApiData);
        };
        return tcs.Task;
    }

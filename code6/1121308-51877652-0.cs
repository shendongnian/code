    public async Task<object> ReceiveAsync(Message message, CancellationToken token)
    {
                //If the connection still open, we do something
                if (!token.IsCancellationRequested)
                {
                 ...
                }
    }

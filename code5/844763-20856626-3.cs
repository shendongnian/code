    public async Task LogToDB(CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
           var message=await MyReceiveAsync();
           SaveMessage(message);
        }
    }

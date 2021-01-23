    public async Task DoWorkAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                ProccessSmsQueue();
            }
            catch (Exception e)
            {
                // Handle exception
            }
            await Task.Delay(TimeSpan.FromMinutes(10), token);
        }
    }

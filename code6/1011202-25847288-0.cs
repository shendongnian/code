    public async Task<IMessage> ReceiveAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            // Try receiving for one second
            IMessage message;
            if (!consumer.TryReceive(out message))
            {
                 await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
            if (message != null)
            {
                return message;
            }
        }
    }

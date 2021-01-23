    private void ImportMethod(/* other parameters? */ CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var messages = ReadMessages(consumer);
            // ... further processing here?
        }
    }

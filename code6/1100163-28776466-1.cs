    async Task CallerA()
    {
        using (new NoSynchronizationContextScope())
        {
            await Method1Async();
        }
    }

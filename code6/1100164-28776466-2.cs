    async Task CallerA()
    {
        using (NoSynchronizationContextScope.Enter())
        {
            await Method1Async();
        }
    }

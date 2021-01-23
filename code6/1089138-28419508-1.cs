    public static async Task RunThread(Action<CancellationToken> act, CancellationToken token)
    {   
        await Task.Run(() => act(token), token);
    }
    public static void ExpensiveOperation(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(100);
        }
    }

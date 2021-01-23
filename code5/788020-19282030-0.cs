    public static string wait(Action<Action<string>> initialAction)
    {
        string message = null;
        using (CancellationTokenSource tokenSource = new CancellationTokenSource(5000))
        {
            initialAction(msg =>
            {
                message = msg;
                tokenSource.Cancel();
            });
            tokenSource.Token.WaitHandle.WaitOne();
        }
        return message;
    }

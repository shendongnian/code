    static CancellationTokenSource Cancel = new CancellationTokenSource();
    public static void Callback(object state)
    {
        Cancel.Cancel();
    }

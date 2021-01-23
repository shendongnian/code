    private List<CancellationTokenSource> StepperCancelTokens = new List<CancellationTokenSource>();
    private int MillisecondsToWait;
    private readonly object _lockThis = new object();
    public Debouncer(int millisecondsToWait = 300)
    {
        this.MillisecondsToWait = millisecondsToWait;
    }
    public void Debounce(Action action)
    {
        CancelAllStepperTokens(); //Cancel previous task tokens
        var tokenSrc = new CancellationTokenSource();
        StepperCancelTokens.Add(tokenSrc); //Add new token
        Task.Delay(MillisecondsToWait).ContinueWith(task =>
        {
             action();
            //Optional
            //lock (_lockThis) RemoveAndDispose(tokenSrc);
        }, 
            tokenSrc.Token
        );
    }
    public void Debounce<T>(Action<T> action, T param)
    {
        CancelAllStepperTokens(); //Cancel previous task tokens
        var tokenSrc = new CancellationTokenSource();
        StepperCancelTokens.Add(tokenSrc); //Add new token
        Task.Delay(MillisecondsToWait).ContinueWith(task =>
        {
                action(param);
        },
            tokenSrc.Token
        );
    }
    public void Debounce2(Action action)
    {
        var tokenSrc = new CancellationTokenSource();
        CancelAllStepperTokens(); //Cancel previous task tokens
        StepperCancelTokens.Add(tokenSrc); //Add new token
        Task.Run(async () =>
        {
            await Task.Delay(MillisecondsToWait);
            if (!tokenSrc.IsCancellationRequested)
            {
                action();
                //lock (_lockThis) RemoveAndDispose(tokenSrc);
            }
        });
    }
    private void CancelAllStepperTokens()
    {
        foreach (var token in StepperCancelTokens) {
            token.Cancel();
            token.Dispose();
        }
        StepperCancelTokens.Clear();
    }
    private void RemoveAndDispose(CancellationTokenSource token)
    {
        StepperCancelTokens.Remove(token);
        token.Dispose();
    }
    public void Dispose()
    {
        CancelAllStepperTokens();
    }
    ~Debouncer()
    {
        Dispose();
    }
}

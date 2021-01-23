    public static IDisposable CreateTimeoutScope(this IDisposable disposable, TimeSpan timeSpan)
    {
        var cancellationTokenSource = new CancellationTokenSource(timeSpan);
        var cancellationTokenRegistration = cancellationTokenSource.Token.Register(disposable.Dispose);
        return new DisposableScope(
            () =>
            {
                cancellationTokenRegistration.Dispose();
                cancellationTokenSource.Dispose();
                disposable.Dispose();
            });
    }

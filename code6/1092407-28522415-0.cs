    private CancellationTokenSource _cts;
    async Task StartBacktestAsync()
    {
      if (_cts != null)
        _cts.Cancel();
      _cts = new CancellationTokenSource();
      try
      {
        await Task.Run(() => Backtest(_cts.Token));
      }
      catch (OperationCanceledException)
      {
        // Any special logic for a canceled operation.
      }
    }
    void Backtest(CancellationToken token)
    {
      ... // periodically call token.ThrowIfCancellationRequested();
    }

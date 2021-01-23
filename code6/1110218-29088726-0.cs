    private CancellationTokenSource _cts;
    private async void start_Click(object sender, EventArgs e)
    {
        _cts = new CancellationTokenSource();
        var token = _cts.Token;
        try
        {
            await Task.Run(() =>
            {
               // Your encoding process
            });
        }
        catch (OperationCanceledException)
        {
           // Handle cancellation
        }
    }
    private void stop_Click(object sender, EventArgs e)
    {
        if (_cts != null)
            _cts.Cancel();
    }

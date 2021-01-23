    private CancellationTokenSource tokenSource;
    private async void button1_MouseEnter(object sender, EventArgs e)
    {
        if (tokenSource != null)
            tokenSource.Cancel();
        tokenSource = new CancellationTokenSource();
        try
        {
            await Task.Delay(500, tokenSource.Token);
            if (!tokenSource.IsCancellationRequested)
            {
                //
            }
        }
        catch (TaskCanceledException ex) { }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        tokenSource.Cancel();
    }

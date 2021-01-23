    public async void TaskDelayTest(CancellationToken token)
    {
        while (LoopCheck)
        {
            for (int i = 0; i < 100; i++)
            {
                textBox1.Text = i.ToString();
                await Task.Delay(1000, token);
            }
        }
    }
    ...
    var tokenSource = new CancellationTokenSource();
    TaskDelayTest(tokenSource.Token);
    ...
    // cancelling
    LoopCheck = false;
    tokenSource.Cancel();

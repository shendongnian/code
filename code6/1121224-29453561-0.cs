    private Task workerTask;
    public Form()
    {
         workerTask = Worker(cts.Token);
    }
    private async Task Worker(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
            await TaskEx.Delay(1000);
    }
    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        cts.Cancel(); // request cancel
        await workerTask; // Wait for worker to finish before closing
    }

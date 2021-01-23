    private void btnSessions_Click(object sender, EventArgs e)
    {
        var tokenSource2 = new CancellationTokenSource();
        CancellationToken ct = tokenSource2.Token;
        Task task = Task.Run(() => DownloadThread(), ct);
    }
    private void DownloadThread()
    {
        while (true)
        {
            //do work
            //cancel if needed
            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }
        }
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
        // Stop the thread
        tokenSource2.Cancel();
    }

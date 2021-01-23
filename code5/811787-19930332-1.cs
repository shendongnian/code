    var cts = new CancellationTokenSource(); // define in class
    CancellationToken ct = cts.Token;
    private void btnSessions_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => DownloadThread(), ct ); // start task
    }
    private void DownloadThread()
    {
        // You need to check this at some point where cancel may occur
        if (ct.IsCancellationRequested)
            ct.ThrowIfCancellationRequested();
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        cancelToken.Cancel(false); // cancel task
    }

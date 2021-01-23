    private CancellationTokenSource _tokenSource2;
    private CancellationToken _token;
    private void btnSessions_Click(object sender, EventArgs e)
    {
        _tokenSource2 = new CancellationTokenSource();
        _token = _tokenSource2.Token;
        Task task = Task.Run(() => DownloadThread(), _token);
    }
    private void DownloadThread()
    {
        while (true)
        {
            //do work
            //cancel if needed
            if (_token.IsCancellationRequested)
            {
                _token.ThrowIfCancellationRequested();
            }
        }
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
        // Stop the thread
        _tokenSource2.Cancel();
    }

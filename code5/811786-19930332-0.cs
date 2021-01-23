    var cancelToken = new CancellationTokenSource(); // define in class
    
    private void btnSessions_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => DownloadThread(), cancelToken.Token); // start task
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        cancelToken.Cancel(false); // cancel task
    }

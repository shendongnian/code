    private RenewalImportProgress(IHubConnectionContext clients)
    {
       Clients = clients;
       _timer = new Timer(ReportProgress, null, _updateInterval, Timeout.Infinite);
    }
    private void ReportProgress(object state)
    {
    	GetProgress(_batchId);
    	_timer.Change(_updateInterval, Timeout.Infinite);
    }

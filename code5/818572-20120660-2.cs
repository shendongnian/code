    private void StartXmlRefresherWithFactory(int sleepMilliseconds)
    {
        _isActive = true;
        Task.Factory.StartNew(() =>
        {
            while (_isActive)
            {
                RefreshXml();
                Thread.Sleep(sleepMilliseconds);
            }
        });
    }

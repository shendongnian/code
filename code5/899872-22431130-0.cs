    public async void Execute()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
        }
    
        var token = _cancellationTokenSource = new CancellationTokenSource();
    
        try
        {
            string dataItem = await _dataService.GetDataAsync(_mainViewModel.Request, _cancellationTokenSource.Token);
            token.ThrowIfCancellationRequested();
            _mainViewModel.Data.Add(dataItem);
        }
        catch (TaskCanceledException)
        {
            //Tidy up ** area of concern **
        }
    }

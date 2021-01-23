    public async void Execute()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
        }
    
        _cancellationTokenSource = new CancellationTokenSource();
        var token = _cancellationTokenSource.Token.
        try
        {
            string dataItem = await _dataService.GetDataAsync(
                _mainViewModel.Request, 
                token);
            token.ThrowIfCancellationRequested();
            _mainViewModel.Data.Add(dataItem);
        }
        catch (TaskCanceledException)
        {
            //Tidy up ** area of concern **
        }
    }

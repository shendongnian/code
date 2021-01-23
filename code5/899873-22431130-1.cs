    try
    {
        string dataItem = await _dataService.GetDataAsync(_mainViewModel.Request, _cancellationTokenSource.Token);
        token.ThrowIfCancellationRequested();
        _mainViewModel.Data.Add(dataItem);
    }
    catch (Exception ex)
    {
        if (ex is TaskCanceledException)
            return
        if (!token.IsCancellationRequested)
        {
            // thrown before the cancellation has been observed,
            // report and re-throw
            MessageBox.Show(ex.Message);
            throw;
        }
        // otherwise, log and ignore
    }

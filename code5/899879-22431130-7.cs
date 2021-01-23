    try
    {
        string dataItem = await _dataService.GetDataAsync(
            _mainViewModel.Request, 
            token);
        token.ThrowIfCancellationRequested();
        _mainViewModel.Data.Add(dataItem);
    }
    catch (Exception ex)
    {
        if (ex is OperationCanceledException)
            return
        if (!token.IsCancellationRequested)
        {
            // thrown before the cancellation has been requested,
            // report and re-throw
            MessageBox.Show(ex.Message);
            throw;
        }
        // otherwise, log and ignore
    }

    Task task = Task.Factory.StartNew(async () =>
    {
        try
        {
            Task.WaitAll(
                _aViewModel.LoadData(_someId),
                _bViewModel.LoadData(_someId)
            );
        }
        catch (Exception ex)
        {
            exceptions.Enqueue(ex);
        }
    })...

    public async override void InitData()
    {
        _domainModel = new DomainModel()
        ProgressIndicatorViewModel.Start();
        _State = Getstate();
        await Task.Run(() => _domainModel.Load(_State, 
            ProgressIndicatorViewModel)).ConfigureAwait(false);
        ImageSelectionViewModel.UpdateState(_State); //returns void not a task!
        
        DispatcherHelper.UIDispatcher.Invoke(() =>
        {
            ProgressIndicatorViewModel.Stop();
            ImageSelectionViewModel.RefreshImages(_imageList)
        });
    }

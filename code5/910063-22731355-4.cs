    public async override void InitData()
    {
        _domainModel = new DomainModel()
        ProgressIndicatorViewModel.Start();
        _State = Getstate();
        await Task.Run(() => _domainModel.Load(_State, 
            ProgressIndicatorViewModel)).ConfigureAwait(false);
        ImageSelectionViewModel.UpdateState(_State); //returns void not a task!
        ProgressIndicatorViewModel.Stop();
        DispatcherHelper.UIDispatcher.Invoke(() => ImageSelectionViewModel.RefreshImages(_imageList));
    }

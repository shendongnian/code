    public async override void InitData()
    {
        _domainModel = new DomainModel()
        ProgressIndicatorViewModel.Start();
        _State = Getstate();
        await Task.Run(async () =>
        { 
            await _domainModel.Load(_State, ProgressIndicatorViewModel))
            ImageSelectionViewModel.UpdateState(_State); //returns void not a task!
        });
        ProgressIndicatorViewModel.Stop();
        ImageSelectionViewModel.RefreshImages(_imageList);
    }

    public async override void InitData()
        {
            _domainModel = new DomainModel()
    
            ProgressIndicatorViewModel.Start();
            _State = Getstate();
            await Task.Factory.StartNew(() => {
                 _domainModel.Load(_State, ProgressIndicatorViewModel).ContinueWith(() => {
                 ImageSelectionViewModel.UpdateState(_State); }); 
               };
            ProgressIndicatorViewModel.Stop();
    
            DispatcherHelper.UIDispatcher.Invoke(() => ImageSelectionViewModel.RefreshImages(_imageList));
        }

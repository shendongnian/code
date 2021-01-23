    public FTViewModel(int JobID)
    {
        _windowCloseAction = new DelegateCommand(OnWindowClose);
        _oFTrn = new ObservableFilesTransmitted(_dataDc, JobID);
        foreach(var item in _oFTrn)
        {
            item.PropertyChanged += FilesTransmitted_PropertyChanged;
        }
        _oFTrn.CollectionChanged += oFTrnCollectionChanged;
    }

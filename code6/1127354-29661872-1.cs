    public FTViewModel(int JobID)
    {
        _windowCloseAction = new DelegateCommand(OnWindowClose);
        _oFTrn = new ObservableFilesTransmitted(_dataDc, JobID);
        _oFTrn.CollectionChanged += oFTrnListChanged;
    }
    void oFTrnListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            if (e.PropertyDescriptor.Name == "DocumentNumber")
            {
                _filesTransmittedChange = true;
            }
        }
        _refreshViews = true;
    }

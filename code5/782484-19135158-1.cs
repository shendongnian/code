    private IResultPanel viewModel = new FirstViewModel();
    public IResultPanel ViewModel
    {
        get { return viewModel; }
        set { if (viewModel != value) { viewModel = value; NotifyPropertyChanged("ViewModel"); } }
    }

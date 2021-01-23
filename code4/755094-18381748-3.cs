    public BaseViewModel ViewModel
    {
        get { return viewModel; }
        set 
        {
            if (viewModel != value) 
            { 
                viewModel = value;
                NotifyPropertyChanged("ViewModel");
            } 
        }
    }

    private MyViewModelBase _displayViewModel;
    public MyViewModelBase DisplayViewModel
    {
        get { return _displayViewModel; }
        set 
        { 
            _displayViewModel = value;
            OnPropertyChanged("DisplayViewModel"); // Raise PropertyChanged
        }
    }

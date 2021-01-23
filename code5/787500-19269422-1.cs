    public ICustomInterface ViewModel
    {
        get { return viewModel; }
        set { viewModel= value; NotifyPropertyChanged("ViewModel"); }
    }
    public string SelectedTitle
    {
        get { return selectedTitle; }
        set 
        {
            selectedTitle = value; 
            NotifyPropertyChanged("SelectedTitle");
            if (SelectedTitle == "Something") ViewModel = new SomethingViewModel();
            if (SelectedTitle == "Other") ViewModel = new OtherViewModel();
        }
    }

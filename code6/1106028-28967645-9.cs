    public ViewModelBase DisplayedDetailViewModel
    {
        get
        {
            return displayedDetailViewModel;
        }
        set
        {
            if (displayedDetailViewModel == value)
            {
                return;
            }
            displayedDetailViewModel = value;
            RaisePropertyChanged("DisplayedDetailViewModel");
        }
    }

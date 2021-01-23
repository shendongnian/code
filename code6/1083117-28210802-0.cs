    public bool IsLoading
    {
        get { return isLoading; }
        set { isLoading = value; NotifyPropertyChanged("IsLoading"); }
    }

    private bool isEnabled;
    public bool IsEnabled
    {
        get{ return isEnabled;}
        set{ isEnabled=value;
             NotifyPropertyChanged("IsEnabled");}
    }

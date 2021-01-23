    private bool _IsButtonEnabled { get; set; }
    public bool IsButtonEnabled
    {
        get { return _IsButtonEnabled ; }
        set
        {
            _IsButtonEnabled = value;
            OnPropertyChanged("IsButtonEnabled");
        }
    }

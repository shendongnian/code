    private string _something;
    public string Something
    {
        get { return _something ?? AppResources.ApplicationTitle; }
        set
        {
            _something = value;
            OnPropertyChanged("Something");
        }
    }

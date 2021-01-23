    public string ValueDisplay
    {
        get { return string.Format("{0:" + ValueFormat + "}", ValueValue); }
    }
    public string ValueFormat
    {
        get { return _valueFormat; }
        set
        {
            _valueFormat = value;
            RaisePropertyChanged("ValueDisplay");
        }
    }
    private string _valueFormat;

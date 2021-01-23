    private String _type;
    public String Type 
    { 
        get
        {
            return _type;
        }
        set
        {
            _type = value;
            OnPropertyChanged("Type");
        }
    }

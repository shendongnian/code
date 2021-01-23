    private string _textBackingField;
        
    public string TestText
    { 
        get
        {
            return _textBackingField;
        }
        set
        {
            _textBackingField = value;
            NotifyPropertyChanged();
        }
    }

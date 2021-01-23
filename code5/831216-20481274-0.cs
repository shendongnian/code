    private string _value;
    public string Value 
    { 
        get{return _value;}
        set
        {
            if (_value == value) return; //notice that "Value" is a confusing name for a property :)
            _value = value;
            OnPropertyChanged("Value");
        }
    }

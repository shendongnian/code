    public Dictionary< ValueType, string > Dict { get; private set; }
    
    private ValueType _prop;
    public ValueType Prop
    {
        get{ return _prop }
        set
        {
            _prop = value;
            NotifyPropertyChanged( "Prop" ); // Implement INotifyPropertyChanged
        }
    }
    public ViewModel()
    {
        Dict = new Dictionary< ValueType, string >()
        {
             { value1, string1 },
             { value2, string2 },
             { value3, string3 }
        };
    }

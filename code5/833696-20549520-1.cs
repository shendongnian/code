    private string _exampleProperty;
    public String ExampleProperty
    {
        get { return _exampleProperty; }
        set
        {
            if (value == _exampleProperty) return;
            _exampleProperty = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = PropertyChanged;
        if (handler != null) 
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

    private int _someInt;
    public int SomeInt
    {
        get { return _someInt; }
        set 
        {
            if(_someInt != value)
            {
                _someInt = value;
                // Helper function in the class which checks to see if propertychanged has any subscribers
                OnPropertyChanged("_someInt"); 
            }
        }
    }

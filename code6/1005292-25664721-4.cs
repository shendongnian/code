    private int myProperty;
    public int MyProperty
    {
        get { return myProperty; }
        set
        {
            if (myProperty != value)
            {
                myProperty = value;
                OnPropertyChanged("MyProperty");
            }
        }
    }

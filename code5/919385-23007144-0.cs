    public someType SomeProperty
    {
        get { return someProperty; }
        set 
        {
            someProperty = value;
            NotifyPropertyChanged("SomeProperty");
            // each time this is changed, you have access to the other property values here
        }
    }

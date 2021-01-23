    public int Value
    { 
        get { return theValue; }
        set
        { 
            if (theValue != value)
            {
                int oldValue = theValue;
                theValue = value;
                if (OnValueChanged != null) OnValueChanged(oldValue, theValue);
                NotifyPropertyChanged("Value"); // Notify property change
            }
        }
    }

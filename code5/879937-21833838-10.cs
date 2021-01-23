    private void OnPropertyChanged(string propertyName){
        var handler = PropertyChanged;
        if (handler != null)
            //One more closing bracket was missing
            handler(this, new PropertyChangedEventArgs(propertyName));
        // With C# 6 this can be replaced with
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public  string MyProperty
    {
        get { return my; }
        set
        {
           if (my == value)
               return;
            my = value;
            OnPropertyChanged("MyProperty");
        }
    }

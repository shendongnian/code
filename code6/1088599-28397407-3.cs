    public string TestValue
    {
        get { return this.testValue; }
        set { this.testValue = value; this.NotifyPropertyChanged("TestValue"); }
    }
    protected virtual void NotifyPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

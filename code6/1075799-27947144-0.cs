    public string Result
    {
        get { return Multiplier * someFixedValue; }
    }
    public string Multiplier
    {
        get { return multiplier; }
        set { multiplier = value; NotifyPropertyChanged("Multiplier", "Result"); }
    }
...
    protected override void NotifyPropertyChanged(params string[] propertyNames)
    {
        if (PropertyChanged != null)
        {
            foreach (string propertyName in propertyNames)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

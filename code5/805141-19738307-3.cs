    public int RedItemCount
    {
        get { return redItemCount; }
        set 
        {
            redItemCount = value;
            NotifyPropertyChanged("RedItemCount", "MissingCount"); 
        }
    }
    public int BlueItemCount
    {
        get { return blueItemCount; }
        set 
        {
            blueItemCount = value;
            NotifyPropertyChanged("BlueItemCount", "MissingCount"); 
        }
    }
    public void NotifyPropertyChanged(params string[] propertyNames)
    {
        if (PropertyChanged != null)
        {
            foreach (string propertyName in propertyNames) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

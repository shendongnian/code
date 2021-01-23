    public DateTime? To
    {
        get { return Get<DateTime?>(); }
        set
        {
            Set(value);
            OnPropertyChanged("To");
            OnPropertyChanged("EndTimeString");
        }
    }

    private string _count;
    public string Count
    {
        get { return _count; }
        set
        {
            _count = value;
            OnPropertyChanged();
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs("Sum"));
        }
    }

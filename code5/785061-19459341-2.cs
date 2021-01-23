    public ICollection<string> ButtonTextCollection
    {
        get { return _buttonTextCollection; }
        set
        {
            _buttonTextCollection = value;
            OnPropertyChanged("ButtonTextCollection");
        }
    }

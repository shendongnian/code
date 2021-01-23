    public BitmapImage Brand
    {
        get
        {
            // ...
        }
        set
        {
            if (Equals(value, _brand)) return;
            _brand = value;
            OnPropertyChanged();
        }
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

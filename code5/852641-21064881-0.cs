    protected void OnPropertyChanged(string propertyName)
    {
        if (propertyName != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

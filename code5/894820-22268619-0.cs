    private void RaisePropertyChanged(string propertyName)
    {
        // take a copy to prevent thread issues
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

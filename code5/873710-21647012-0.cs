    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            Application.Current.Dispatcher.Invoke(() =>
                handler(this, new PropertyChangedEventArgs(propertyName)));
        }
    }

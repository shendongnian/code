    // INotifyPropertyChanged event for static properties!
    public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
    private static void NotifyStaticPropertyChanged(string propertyName)
    {
        if (StaticPropertyChanged != null)
        {
            StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }
    }

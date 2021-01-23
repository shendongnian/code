    public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged
             = delegate { };
    private static void NotifyStaticPropertyChanged(string propertyName)
    {
       StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
    }

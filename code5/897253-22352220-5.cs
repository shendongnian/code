    private static event EventHandler<PropertyChangedEventArgs> staticPC
                                                         = delegate { };
    public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged
    {
       add { staticPC += value; }
       remove { staticPC -= value; }
    }
    protected static void NotifyStaticPropertyChanged(string propertyName)
    {
       staticPC(null, new PropertyChangedEventArgs(propertyName));
    } 

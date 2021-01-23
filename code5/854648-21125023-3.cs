    public AppType AppType
    {
        get
        {
            return appType;
        }
        set
        {
            if( Equals( appType, value ) ) return;
            appType = value;
            OnPropertyChanged( "AppType" );
        }
    }

    public FacebookSession CurrentSession
    {
        get
        {
            return FacebookSessionCacheProvider.Current.GetSessionData();
        }
    }

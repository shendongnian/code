    public bool PowerUserMode
    {
        get
        {
            return GetApp() != Apps.ApplicationB;
        }
    }

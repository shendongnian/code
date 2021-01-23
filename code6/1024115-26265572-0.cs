    public Color BorderColor
    {
        get { return BorderColor; }
        set
        {
            if (!FollowsScheme)
                BorderColor = value;   // BOOM!
        }
    }

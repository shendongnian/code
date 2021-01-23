    public static Player1Screen Player1Screen
    {
        get
        {
            return Application.Current.Windows
                .OfType<Player1Screen>()
                .FirstOrDefault();
        }
    }

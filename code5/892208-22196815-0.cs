    public static bool checkCookies()
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        if (settings.Contains("sessionCookie"))
        {
            Cookie c = settings["sessionCookie"] as Cookie;
            Cookie newCookie = new Cookie(c.Name, c.Value, c.Path);
            Uri uri = new Uri(ROOT + "/authentication");
            handler.CookieContainer.Add(uri, newCookie);
            return true;
        }
        return false;
    }

    public static void SaveStatusBarColor()
    {
        // get status bar color
        var statusBar = StatusBar.GetForCurrentView();
        var color = statusBar.BackgroundColor;
        // convert color to hex string
        var hexCode = color.HasValue ? color.Value.ToString() : "";
        // store color in local settings
        ApplicationData.Current.LocalSettings.Values["StatusBarColor"] = hexCode;
    }
    public static void LoadStatusBarColor()
    {
        // get color hex string from local settings
        var hexCode = ApplicationData.Current.LocalSettings.Values["StatusBarColor"] as string;
        if (string.IsNullOrEmpty(hexCode))
            return;
        // convert hexcode to color
        var color = new Color();
        color.A = byte.Parse(hexCode.Substring(1, 2), NumberStyles.AllowHexSpecifier);
        color.R = byte.Parse(hexCode.Substring(3, 2), NumberStyles.AllowHexSpecifier);
        color.G = byte.Parse(hexCode.Substring(5, 2), NumberStyles.AllowHexSpecifier);
        color.B = byte.Parse(hexCode.Substring(7, 2), NumberStyles.AllowHexSpecifier);
        // set the status bar color
        var statusBar = StatusBar.GetForCurrentView();
        statusBar.BackgroundColor = color;
    }

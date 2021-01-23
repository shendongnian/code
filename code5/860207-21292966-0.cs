    try
    {
        var uri = new Uri(
            "PresentationFramework.Aero;component\\themes/aero.normalcolor.xaml", 
            UriKind.Relative);
        var aeroResources = Application.LoadComponent(uri) as ResourceDictionary;
        if (aeroResources != null)
            Application.Current.Resources.MergedDictionaries.Add(aeroResources);
    }
    catch
    {
        //
        // Proceed with the current theme.
        //
    }

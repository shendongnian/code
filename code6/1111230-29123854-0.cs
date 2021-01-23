    /// <summary>
    /// Loads localization based on culture.
    /// </summary>
    /// <param name="dictionary">The dictionary to load localization to</param>
    /// <param name="basePath">The base path of the localization files. See remarks for further info.</param>
    /// <param name="cultureInfo">Culture to load localization for.</param>
    /// <remarks>
    /// The loaded localization file will be <code>basenameLocalization.languagecode.xaml</code>
    /// (e.g. <code>MainWindowLocalization.de.xaml</code>), or <code>basenameLocalization.languagecode.xaml</code>
    /// for the default localization.
    /// </remarks>
    internal static void ReplaceLocalization(
        ResourceDictionary dictionary,
        string basePath,
        CultureInfo cultureInfo)
    {
        ResourceDictionary dict = new ResourceDictionary();
        // Clean out old localization
        ResourceDictionary oldLocalization = null;
        foreach (ResourceDictionary d in dictionary.MergedDictionaries)
        {
            if (d.Source.OriginalString.StartsWith(basePath + "Localization."))
            {
                oldLocalization = d;
            }
        }
        if (oldLocalization != null)
        {
            dictionary.MergedDictionaries.Remove(oldLocalization);
        }
        // Get thee language
        string language = "";
        if (cultureInfo.Name != null)
        {
            // We only need to look at the first two characters to determine language
            language = cultureInfo.Name.Substring(0, 2);
        }
        bool defaultLanguage = false;
        // Filter languages such that only supported languages are loadable,
        // and any other defaults to the default/neutral language.
        switch (language)
        {
            case "da":
                break;
            default:
                defaultLanguage = true;
                break;
        }
        // Construct the URI
        string uri;
        if (defaultLanguage)
        {
            uri = basePath + "Localization.xaml";
        }
        else
        {
            uri = basePath + "Localization." + language + ".xaml";
        }
        // Load new dictionary
        dict.Source = new Uri(uri, UriKind.Relative);
        dictionary.MergedDictionaries.Add(dict);
    }

    public static void ChangeTheme(string themeName)
    {
        string desiredTheme = themeName;    
        Uri uri;
        ResourceDictionary resourceDict;
        ResourceDictionary finalDict = new ResourceDictionary();
    
        // Clear then load Base theme
        Application.Current.Resources.MergedDictionaries.Clear();
        themeName = "Base";
        foreach (var themeFile in Util.GetDirectoryInfo(Path.Combine(ThemeFolder, themeName)).GetFiles())
        {
            uri = new Uri(Util.GetPath(Path.Combine(ThemeFolder, themeName + @"\" + themeFile.Name)));
            resourceDict = new ResourceDictionary { Source = uri };
            foreach (DictionaryEntry de in resourceDict)
            {
                finalDict.Add(de.Key, de.Value);
            }
        }
        // If all you want is Base, we are done
        if (desiredTheme == "Base")
        {
            Application.Current.Resources.MergedDictionaries.Add(finalDict);
            return;
        }
    
        // Now load desired custom theme, replacing keys found in Base theme with new values, and adding new key/values that didn't exist before
        themeName = desiredTheme;
        bool found;
        foreach (var themeFile in Util.GetDirectoryInfo(Path.Combine(ThemeFolder, themeName)).GetFiles())
        {
            uri = new Uri(Util.GetPath(Path.Combine(ThemeFolder, themeName + @"\" + themeFile.Name)));
            resourceDict = new ResourceDictionary { Source = uri };
            foreach (DictionaryEntry x in resourceDict)
            {
                found = false;
                // Replace existing values
                foreach (DictionaryEntry z in finalDict)
                {
                    if (x.Key.ToString() == z.Key.ToString())
                    {
                        finalDict[x.Key] = x.Value;
                        found = true;
                        break;
                    }
                }
    
                // Otherwise add new values
                if (!found)
                {
                    finalDict.Add(x.Key, x.Value);
                }
            }
        }
    
        // Apply final dictionary
        Application.Current.Resources.MergedDictionaries.Add(finalDict);
    }

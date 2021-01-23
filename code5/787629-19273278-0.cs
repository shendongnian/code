    private void MergeCustomColors(String Theme)
    {
        ResourceDictionary Dictionaries = new ResourceDictionary();
        String source = String.Format(Theme);
        var themeStyles = new ResourceDictionary { Source = new Uri(source, UriKind.Relative) };
        Dictionaries.MergedDictionaries.Add(themeStyles);
        ResourceDictionary appResources = Current.Resources;
        foreach (DictionaryEntry entry in Dictionaries.MergedDictionaries[0])
        {
            SolidColorBrush ColorBrush = entry.Value as SolidColorBrush;
            SolidColorBrush ExistingBrush = appResources[entry.Key] as SolidColorBrush;
            if (ExistingBrush != null && ColorBrush != null) { ExistingBrush.Color = ColorBrush.Color; }
        }
    }

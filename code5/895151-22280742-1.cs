    ResourceDictionary res = new ResourceDictionary();
    res.Source = new Uri("LIBRARYNAME;fullclassname" + ".xaml", UriKind.Relative);
    
    try{
        Application.Current.Resources.MergedDictionaries.Add(res);
    }
    catch {
        // may be resource was loaded ?
    }

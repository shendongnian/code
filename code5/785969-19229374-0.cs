    public override Uri MapUri(Uri uri)
    {
        if (uri.OriginalString == "/EntryPage.xaml")
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("WasLaunched"))
            {
                 uri = new Uri("/FirstRunInfoPage.xaml", UriKind.Relative);
            }
            else
            {
                 uri = new Uri("/MainPage.xaml", UriKind.Relative);
             }
         }
            return uri;
     } 

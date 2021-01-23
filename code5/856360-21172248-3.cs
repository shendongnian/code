    protected override void OnNavigatedTo(NavigationEventArgs e)  
    {
        for (int i = 0; i < IsolatedStorageSettings.ApplicationSettings.Count; i++)
        {
            lstStops.Items.Add(IsolatedStorageSettings.ApplicationSettings.ElementAt(i).Value as string);
        }
      base.OnNavigatedTo(e);
    }

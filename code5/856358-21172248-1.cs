    protected override void OnNavigatedTo(NavigationEventArgs e)  
    {
        for (int i = 0; i < IsolatedStorageSettings.ApplicationSettings.Count; i++)
        {
            object temp = IsolatedStorageSettings.ApplicationSettings.ElementAt(i);
            lstStops.Items.Add((string)temp);
        }
      base.OnNavigatedTo(e);
    }

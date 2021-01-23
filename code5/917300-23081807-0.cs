    List<MyConnection.locationList.locations> source;
    private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            source = new List<MyConnection.locationList.locations>();
            if (!settings.Contains("firstrun"))
            {
                source.Add(new MyConnection.locationList.locations("Dulles, VA"));
                source.Add(new MyConnection.locationList.locations("Dulles, VA (Q)"));
            }
    }

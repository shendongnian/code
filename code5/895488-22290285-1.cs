    protected override void OnNavigatedTo(...)
    {
        if (NavigationContext.QueryString.ContainsKey("note"))
        {
            LocationDetails myFile = new LocationDetails();
            myFile.OpenSavedFile();
        }
    }

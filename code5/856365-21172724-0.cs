    //Loading items into Dictionary
    Dictionary<string, string> tempDictionary = new Dictionary<string, string>();
    if (IsolatedStorageSettings.ApplicationSettings.Contains("stopNumberDictionary"))
    {
	    tempDictionary = IsolatedStorageSettings.ApplicationSettings["stopNumberDictionary"] as Dictionary<string, string>;
    }
    else
    {
	    IsolatedStorageSettings.ApplicationSettings.Add("stopNumberDictionary", tempDictionary);
    }
    if (!tempDictionary.Contains(stopNumber))
    {
	    tempDictionary.Add(stopNumber, stopAddress);
    }
    IsolatedStorageSettings.ApplicationSettings["stopNumberDictionary"] = tempDictionary;
    IsolatedStorageSettings.ApplicationSettings.Save();
    //Then load Dictionary OnNavigatedTo
    protected override void OnNavigatedTo(NavigationEventArgs e)  
    {
	    Dictionary<string, string> tempDictionary = new Dictionary<string, string>();
	    if (IsolatedStorageSettings.ApplicationSettings.Contains("stopNumberDictionary"))
	    {
		    tempDictionary = IsolatedStorageSettings.ApplicationSettings["stopNumber"] as Dictionary<string, string>;
	    }
    
	    foreach(KeyValuePair<string, string> entry in tempDictionary)
	    {
		    lstStops.Items.Add(entry.Value as string);
	    }
	    base.OnNavigatedTo(e);
    }

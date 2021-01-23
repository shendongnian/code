    private DateTime _dateOne;
    public DateTime DateOne
    {
    	get { return _dateOne; }
    	set
    	{
    		_dateOne = value;
    		SaveDate(value);
    		NotifyPropertyChanged("DateOne");
    	}
    }
    
    SaveDate(DateTime date)
    {
    	using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
    	{
    		if (isf.FileExists("DateOne"))
    		   isf.DeleteFile("DateOne");
    		IsolatedStorageSettings.ApplicationSettings["DateOne"] = date;
    		IsolatedStorageSettings.ApplicationSettings.Save();
    	}
    }

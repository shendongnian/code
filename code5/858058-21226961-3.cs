    private async void SomeMethod()
    {
    	....
    	if (xdoc.Element("Application") != null)
    	{
    		var data = from query in xdoc.Descendants("AppID")
    				   select new APP
    				   {
    					   AppID = query.Value,
    					   AppName = await GetName(query.Value),
    				   };
    		itemGridView.DataContext = data;
    	}
    	....
    }

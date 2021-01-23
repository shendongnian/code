    foreach (String StationID in StationIDList) 
    { 
    	string url = @"http://api.wunderground.com/api/" + wundergroundkey + "/history_" + Date + "/q/pws:" + StationID + ".json";
    	Uri uri = new Uri (url);
    	WebRequest webRequest = WebRequest.Create (uri);
    	WebResponse response = webRequest.GetResponse ();
    	StreamReader streamReader = new StreamReader (response.GetResponseStream ());
    	String responseData = streamReader.ReadToEnd ();
    
    	try
    	{
    		var container = JsonConvert.DeserializeObject<HistoryResponseContainer> (responseData);
    
    		foreach (var observation in container.history.observations) 
    		{
    			CurrentData.Write (StationID + " ");
    			DateTime date = observation.date.Value;
    			DateTime utc = observation.utcdate.Value;
    
    			if (date.Minute == 0 || date.Minute % 5 == 0) 
    			{
    				CurrentData.Write (date.Hour + ":" + date.Minute + " " + observation.wdird + " " + observation.wspdi);
    			}
    
    			CurrentData.Write ("\n");
    
    		}
    	}
    	catch(/* ... */)
    	{
    		// ...
    	}
    }

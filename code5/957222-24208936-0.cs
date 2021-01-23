    void MyCallback(FBResult result)
	{
		if (result != null) 
		{
			var response = DeserializeResponse(result.Text);
			foreach(object c in response)
			{
				var jsonObject = c as Dictionary<string, object>;
				string[] ids = jsonObject["id"].ToString().Split('_');
				FB.API (string.Format ("/{0}", ids[0]), Facebook.HttpMethod.GET, MyCallbackGet);
			}
		}
	}
    public List<object> DeserializeResponse (string response)
    	{		
    		var responseObject = Json.Deserialize (response) as Dictionary<string, object>;
    		object scoresh;
    		var scores = new List<object> ();
    		if (responseObject.TryGetValue ("data", out scoresh)) 
    		{
    			scores = (List<object>)scoresh;
    		}
    		
    		return scores;
    	}

    public string GetJsonPropertyValue(string json, string query)
    {
	    JToken token = JObject.Parse(json);
	
	    foreach(string queryComponent in query.Split('.'))
	    {
		    token = token[queryComponent];
	    }
	    return token.ToString();
    }

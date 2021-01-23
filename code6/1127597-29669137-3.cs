    private static string CreateUrl(string baseUrl, Dictionary<string, string> parameters)
    {
    	var stringBuilder = new StringBuilder(baseUrl);
    	var firstTime = true;
    
    	// Going through all the parameters
    	foreach (var arg in parameters)
    	{
    		if (firstTime)
    		{
    			stringBuilder.Append('?'); // first parameter is appended with a ? - www.example.com/index.html?abc=3
    			firstTime = false; // All other following parameters should be added with a &
    		}
    		else
    		{
    			stringBuilder.Append('&'); // all  other parameters are appended with a & - www.example.com/index.html?abc=3&abcd=4&abcde=8
    		}
    
    		var key = WebUtility.UrlEncode(arg.Key); // Converting characters which are not allowed in the url to escaped values
    		var value = WebUtility.UrlEncode(arg.Value); // Same goes for the value
    
    		stringBuilder.Append(key + '=' + value); // Writing the parameter in the format key=value
    	}
    
    	return stringBuilder.ToString(); // Returning the url with parameters
    }

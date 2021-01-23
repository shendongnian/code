    var valueEntries = Request.QueryString.GetValues((string)null) ?? new string[] {};
    if (valueEntries.Contains("query", StringComparer.OrdinalIgnoreCase))
    {
    	// value is specify in querystring
    }
    else
    {
    	// value is NOT specify in querystring
    }

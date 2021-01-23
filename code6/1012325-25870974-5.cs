    public static string GetQueryString(this HttpRequestMessage request, string key)
    {      
        // IEnumerable<KeyValuePair<string,string>> - right!
        var queryStrings = request.GetQueryNameValuePairs();
        if (queryStrings == null)
            return null;
        var match = queryStrings.FirstOrDefault(kv => string.Compare(kv.Key, key, true) == 0);
        if (string.IsNullOrEmpty(match.Value))
            return null;
        return match.Value;
    }

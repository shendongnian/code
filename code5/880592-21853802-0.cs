    // uri: /Api/Data/test 
    public IEnumerable<object> Get()
    {
        NameValueCollection nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
        var contains = nvc["nameContains"];
        // BL with nameContains here
    }

    public IEnumerable<string> Get()
    {
        List<string> retval = new List<string>();
    
        var qryPairs = Request.GetQueryNameValuePairs();
        foreach (var q in qryPairs)
        {
            retval.Add("Key: " + q.Key + " Value: " + q.Value);
        }
    
        return retval;
    }

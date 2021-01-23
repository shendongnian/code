    public IDictionary<string, object> ToDictionary(Exception ex)
    {
        var returnValue = new Dictionary<string, object>();
    
        returnValue.Add("Message", ex.Message);
        returnValue.Add("...", ex....);
    
        return returnValue;
    }

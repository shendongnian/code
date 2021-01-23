    public MyObject GetMyObject(int size, string cultureId, string extra)
    {
        // Input validation first
        ...
    
        // Determine cache key
        string cacheKey = size.ToString() + cultureId.ToString() + extra.ToString();
    
        // rest of your code here
    }

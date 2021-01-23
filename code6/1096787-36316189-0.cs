    public string GetRequestIP(bool tryUseXForwardHeader = true)
    {
        string ip = null;
    
        if (tryUseXForwardHeader)
            ip = GetHeaderValueAs<string>("X-Forwarded-For");
    
        // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
        if (ip.IsNullOrWhitespace() && _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress != null)
            ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
    
        if (ip.IsNullOrWhitespace())
            ip = GetHeaderValueAs<string>("REMOTE_ADDR");
    
        // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.
                
        if (ip.IsNullOrWhitespace())
            throw new Exception("Unable to determine caller's IP.");
    
        return ip;
    }
        
    public T GetHeaderValueAs<T>(string headerName)
    {
        StringValues values;
    
        if (_httpContextAccessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
        {
            string rawValues = values.ToString();   // writes out as Csv when there are multiple.
    
            if (!rawValues.IsNullOrEmpty())
                return (T)Convert.ChangeType(values.ToString(), typeof(T));
        }
        return default(T);
    }

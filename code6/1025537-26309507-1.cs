    public string Combine(string format, params object[] args)
    { 
        var parameterize = string.Format(format, args);
        return parameterize;
    }

    /// <summary>
    ///     Returns Current method name
    /// </summary>
    /// <returns>callers method name</returns>
    public string GetCurrentMethod([CallerMemberName] string callerName = "")
    {
    	return callerName;
    }

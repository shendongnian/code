    /// <summary>
    /// Call this from another class to update a zone.
    /// </summary>
    /// <param name="host">The full name of the host</param>
    /// <returns></returns>
    public string Update(String host)
    {
        string url = BuildUrl(host, Ip);
        return PerformUpdate(url);
    }

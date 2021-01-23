    void Main()
    {
        var timeZoneIds = new HashSet<string>(TimeZoneInfo
            .GetSystemTimeZones()
            .Select(tzi => tzi.Id));
    
        timeZoneIds.Contains("UTC-11").Dump();
    }

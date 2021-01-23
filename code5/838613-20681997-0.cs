    void Main()
    {
        var timeZones = TimeZoneInfo
            .GetSystemTimeZones()
            .ToDictionary(stz => stz.Id);
    
        TimeZoneInfo tz;
        if (timeZones.TryGetValue("UTC-11", out tz))
            tz.Dump();
        else
            Debug.WriteLine("No such timezone");
    }

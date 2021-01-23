    ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
    
    foreach (TimeZoneInfo zone in zones)
    {
         Console.WriteLine(zone.Id);
    }

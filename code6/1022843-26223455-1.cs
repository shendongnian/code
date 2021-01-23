    string apiTime = "10/14/2014 8:30 AM (America/Los Angeles)";
    
    int timeZoneStart = apiTime.IndexOf('(');
    
    string timeZonePart = apiTime.Substring(timeZoneStart)
        .Replace("(", string.Empty) // remove parenthesis
        .Replace(")", string.Empty) // remove parenthesis
        .Trim() // clear any other whitespace
        .Replace(" ", "_"); // standard tz uses underscores for spaces
        // (America/Los Angeles) will become America/Los_Angeles
    
    string datePart = apiTime.Substring(0, timeZoneStart).Trim();
    
    DateTime apiDate = DateTime.Parse(datePart);
    
    TimeZoneInfo tzi = OlsonTimeZoneToTimeZoneInfo(timeZonePart);
    
    DateTime apiDateTimeConverted = TimeZoneInfo.ConvertTime(apiDate, tzi);

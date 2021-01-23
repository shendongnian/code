    public static DateTime BuildDateTime(this DateTime date, string time)
    {
        if(string.IsNullOrWhiteSpace(time))
            return date; 
            
        TimeSpan ts;
        if(TimeSpan.TryParse(time, out ts))
            return date.Add(ts);
        else 
            return date;
    }

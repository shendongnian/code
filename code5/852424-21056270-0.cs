    public DateTime convert(string date)
    {
        int hour = int.Parse(date.Substring(0, 2));
        int minute = int.Parse(date.Substring(2, 2));
        if (hour < 12 && date.Substring(4, 2) == "PM")
        {
            hour = hour + 12;
        }
    
        return new DateTime(2014, 1, 10, hour, minute, 0);
    }

    public DateTime ParseDateTime(string dt)
    {
        DateTime d;
        if (DateTime.TryParseExact(dt, "'Posted on' dddd, MMM d'st', yyyy 'at' hh:mm tt" , null, System.Globalization.DateTimeStyles.None, out d))	
            return d;	
        if (DateTime.TryParseExact(dt, "'Posted on' dddd, MMM d'nd', yyyy 'at' hh:mm tt", null, System.Globalization.DateTimeStyles.None, out d))
            return d;
        if (DateTime.TryParseExact(dt, "'Posted on' dddd, MMM d'rt', yyyy 'at' hh:mm tt", null, System.Globalization.DateTimeStyles.None, out d))
            return d;
        if (DateTime.TryParseExact(dt, "'Posted on' dddd, MMM d'th', yyyy 'at' hh:mm tt", null, System.Globalization.DateTimeStyles.None, out d))
            return d;
    
        throw new InvalidOperationException("Not a valid DateTime string");
    }

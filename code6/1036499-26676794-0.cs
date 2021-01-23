    public DateTime JulianToDateTime(double julianDate) {
        double unixTime = (julianDate - 2440587.5) * 86400;
    
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime();
    
        return dtDateTime;
    }

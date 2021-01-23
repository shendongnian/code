    public DateTime ConvertDate(long unixTime)
    {
        var date= new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return date.AddSeconds(unixTime);
    }

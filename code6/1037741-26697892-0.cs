    private static void Main(string[] args)
    {
        DateTime result = ParseOrdinalDateTime("Friday 29th August at 18:30");
    }
    public static DateTime ParseOrdinalDateTime(string dt)
    {
        DateTime d;
        if (DateTime.TryParseExact(dt, "dddd d\"th\" MMMM \"at\" HH:mm",  CultureInfo.CreateSpecificCulture("en-GB"), DateTimeStyles.AssumeLocal, out d))
        {
            return d;
        }
        
        throw new InvalidOperationException("Not a valid DateTime string");
    }

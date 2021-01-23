    private static readonly Dictionary<string,string> TZMap = new Dictionary<string, string>
    {
        // Defined by RFC822, but not known to .NET
        {"UT", "+0000"},
        {"EST", "-0500"},
        {"EDT", "-0400"},
        {"CST", "-0600"},
        {"CDT", "-0500"},
        {"MST", "-0700"},
        {"MDT", "-0600"},
        {"PST", "-0800"},
        {"PDT", "-0700"},
        // Extraneous, as found in your data
        {"WET", "+0000"},
        {"MET", "+0100"}
    };
    public static DateTimeOffset Parse(string s)
    {
        // Get the time zone part of the string
        var tz = s.Substring(s.LastIndexOf(' ') + 1);
        // Replace time zones defined in the map
        if (TZMap.ContainsKey(tz))
        {
            s = s.Substring(0, s.Length - tz.Length) + TZMap[tz];
        }
        // Replace time zone offsets with leading characters
        if (tz.StartsWith("GMT+") || tz.StartsWith("GMT-") || tz.StartsWith("UTC+") || tz.StartsWith("UTC-"))
        {
            s = s.Substring(0, s.Length - tz.Length) + tz.Substring(3);
        }
            
        DateTimeOffset dto;
        if (DateTimeOffset.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out dto))
        {
            return dto;
        }
        throw new ArgumentException("Could not parse value: " + s);
    }

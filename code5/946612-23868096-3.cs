    // try to parse the 'date' part, or return DateTime.MaxValue
    private static DateTime TryParseDate(string filename)
    {
        if (filename.Length < 17)
            return DateTime.MaxValue;
        var datePart = filename.Substring(11, 6);
        if (!datePart.All(char.IsDigit))
            return DateTime.MaxValue;
            
        DateTime date;
        if (!DateTime.TryParseExact(datePart, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out date))
            return DateTime.MaxValue;
        return date;
    }

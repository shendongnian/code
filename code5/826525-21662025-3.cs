    private DateTime DecodeDate(int Start)
    {
        // If your filename is 'ABC-01234 2008-10-21@012345.bin' then Start should = 10
        DateTime date;
        var datePart = filename.Substring(Start, 10);
        var culture = CultureInfo.InvariantCulture;
        var style = DateTimeStyles.None;
        // note since you are telling it the specific format of your date string
        // the culture info is not relevant.  Also note that "yyMMdd" below can be
        // changed to fit your parsing needs yyyy = 4 digit year, MM = 2 digit month
        // and dd = 2 digit day.
        if (!DateTime.TryParseExact(datePart, "yyyy-MM-dd", culture, style, out date))
        {
            // TryParseExact returns false if it couldn't parse the date.
            // Since it failed to properly parse the date... do something 
            // here like throw an exception.
            throw new Exception("Unable to parse the date!");
        }
        return date;
    }

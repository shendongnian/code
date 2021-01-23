    public static bool IsDateBeforeOrToday(string input)
    {
        DateTime pDate;
        if(!DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out pDate))
        {
            //Invalid date
            //log , show error
            return false;
        }
        return DateTime.Today <= pDate;
    }

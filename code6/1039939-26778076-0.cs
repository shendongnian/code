    public static DateTime? ParseDate_Mdyyyy(string date)
    {
        if (date == null)
            return null;
        if (date.Length < 6)
            return null;
        if (date.Length == 6)
            date = date.Insert(0, "0").Insert(2, "0");
        DateTime dt;
        if (DateTime.TryParseExact(date, "MMddyyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out dt))
            return dt;
        return null;
    }

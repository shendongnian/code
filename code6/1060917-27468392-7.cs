    public static DateTime? ParseDate_Mdyyyyhmmsstt(string date)
    {
        if (date == null)
            return null;
        if (date.Length < 14)
            return null;
        if (date.Length == 14)
            date = date.Insert(0, "0").Insert(8, "0");
        DateTime dt;
        if (DateTime.TryParseExact(date, "Mdyyyyhmmsstt",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out dt))
            return dt;
        return null;
    }

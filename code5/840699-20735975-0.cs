    DateTime myDate;
    if (!DateTime.TryParseExact(text, "yyyy-MM-dd HH:mm:ss",
                               System.Globalization.CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out myDate);
    {
        myDate = DateTime.ParseExact(text, "dd-MM-yyyy HH:mm:ss",
                               System.Globalization.CultureInfo.InvariantCulture);
    }

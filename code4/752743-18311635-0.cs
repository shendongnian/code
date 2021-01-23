    string[] formats = { "MMM dd HH:mm:ss +ffff yyyy" };
    DateTime result;
    string date = "Aug 16 21:06:52 +0000 2013";
    if (DateTime.TryParseExact(date, formats, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
    {
        // i prefer this method though
    }

    public static DateTime? TryGetDate(this string dateString, string format = null)
    {
        DateTime dt;
        bool success;
        if (format == null)
            success = DateTime.TryParse(dateString, out dt);
        else
            success = DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out dt);
        return success ? (DateTime?)dt : (DateTime?)null;
    }

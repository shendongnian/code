    public static DateTime? TryGetDate(this string dateString, IFormatProvider provider, params string[] formats)
    {
        DateTime dt;
        bool success;
        success = DateTime.TryParseExact(dateString, formats, provider, DateTimeStyles.None, out dt);
        return success ? (DateTime?)dt : (DateTime?)null;
    }

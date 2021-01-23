    public static DateTime? TryGetDate(this string dateString, IFormatProvider provider, params string[] formats)
    {
        DateTime dt;
        var success = DateTime.TryParseExact(dateString, formats, provider, DateTimeStyles.None, out dt);
        return success ? dt : (DateTime?)null;
    }

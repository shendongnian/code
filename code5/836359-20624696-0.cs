    public static string GetStringOrNull(this IDataReader reader, int ordinal)
    {
        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }
    public static DateTime? GetDateTimeOrNull(this IDataReader reader, int ordinal)
    {
        return reader.IsDBNull(ordinal) ? null : (DateTime?)reader.GetDateTime(ordinal);
    }

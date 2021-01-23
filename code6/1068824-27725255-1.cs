    public static string TryGetString(this IDataRecord record, string fieldName, string defaultValue = "")
    {
        return TryGetValue(record, fieldName, defaultValue);
    }
    
    public static int TryGetInt32(this IDataRecord record, string fieldName, int defaultValue = 0)
    {
        return TryGetValue(record, fieldName, defaultValue);
    }

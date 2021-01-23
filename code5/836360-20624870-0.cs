    public static string GetStringOrEmptyString(this IDataReader reader, int ordinal)
    {
        if (reader.IsDBNull(ordinal)) {
            // if its DBNULL, return empty string
            return "";
        } else {
            // otherwise return thew value as string
            return reader.GetString(ordinal);
        }
    }

    public static int SafeGetInt(this SqlDataReader reader, string colName)
    {
        var colIndex = reader.GetOrdinal(colName);
        return !reader.IsDBNull(colIndex) ? reader.GetInt32(colIndex) : default(int);
    }

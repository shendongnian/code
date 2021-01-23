    protected static DataRow[] GetRows(DataTable dataTable, string keyColumn, string keyValue)
    {
        return dataTable.Rows
            .OfType<DataRow>()
            .Where(row => SafeContains(row[keyColumn], keyValue, StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }
    
    private static bool SafeContains(object source, string value, StringComparison stringComparison)
    {
        var s = source as string;
        if (string.IsNullOrEmpty(s))
            return false;
        return s.IndexOf(value, stringComparison) >= 0;
    }

    public static List<Dictionary<string, string>> GetDataTableDictionaryList(DataTable dt)
    {
        return dt.AsEnumerable().Select(
            row => dt.Columns.Cast<DataColumn>().ToDictionary(
                column => column.ColumnName,
                column => row[column].ToString()
            )).ToList();
    }

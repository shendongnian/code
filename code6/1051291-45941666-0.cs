    public static void UpdateColumns<TValue>(this DataTable dataTable,
        IDictionary<string, TValue> columnValuePair)
    {
        foreach (DataRow dataRow in dataTable.Rows)
        {
            foreach (var pair in columnValuePair)
            {
                dataRow[pair.Key] = pair.Value;
            }
        }
    }

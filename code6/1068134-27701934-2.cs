    public static IEnumerable<string> GetHeaderColumns (this DataTable dataTable) 
    {
        if (dataTable == null || !dataTable.Columns.Any())
        {
            yield break;
        }
        foreach (var col in dataTable.Columns.Cast<DataColumn>())
        {
            yield return col.ColumnName;
        }
    }

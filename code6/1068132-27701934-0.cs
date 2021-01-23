    public IEnumerable<string> GetHeaderColumns (IEnumerable<DataColumn> columns) 
    {
        foreach (var col in columns)
        {
            yield return col.ColumnName;
        }
    }

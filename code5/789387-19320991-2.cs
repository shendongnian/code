    List<DataColumn> columnsToRemove = new List<DataColumn>();
    foreach (DataColumn dc in dt.Columns)
    {
        if (list.Any(ci => ci.ColumnName == dc.ColumnName))
        {
            continue;
        }
        columnsToRemove.Add(dc);
    }
    foreach (DataColumn dc in columnsToRemove)
    {
        dt.Columns.Remove(dc);
    }

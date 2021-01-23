    foreach (DataColumn dc in dt.Columns)
    {
        if (list.Any(ci => ci.ColumnName == dc.ColumnName))
        {
            continue;
        }
        dt.Columns.Remove(dc);
    }

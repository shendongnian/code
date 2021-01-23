    foreach (DataColumn dc in dt.Columns)
    {
        if (list.SingleOrDefault(ci => ci.ColumnName == dc.ColumnName) != null)
        {
            continue;
        }
        dt.Columns.Remove(dc);
    }

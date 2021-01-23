    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in table.Columns)
        {
            if (row.IsNull(col))
                row.SetField(col, String.Empty);
        }
    }

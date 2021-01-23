    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in table.Columns)
        {
            string value = row.Field<string>(col);
            if(value == null)
                row.SetField(col, String.Empty);
        }
    }

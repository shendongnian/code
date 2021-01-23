    DataTable table = Select.Execute().Tables[0];
    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in table.Columns)
        {
            string colName = col.ColumnName;
            object value = row[col];
            // ...
        }
    }

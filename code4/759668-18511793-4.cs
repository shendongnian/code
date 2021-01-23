    if (reader.HasRows)
    {
        DataTable schemaTable = reader.GetSchemaTable();
        DataTable data = new DataTable();
        foreach (DataRow row in schemaTable.Rows)
        {
            string colName = row.Field<string>("ColumnName");
            Type t = row.Field<Type>("DataType");
            data.Columns.Add(colName, t);
        }
        while (reader.Read())
        {
            foreach (DataColumn col in data.Columns)
            {
                var newRow = data.Rows.Add();
                newRow[col.ColumnName] = reader[col.ColumnName];
            }
        }
    }

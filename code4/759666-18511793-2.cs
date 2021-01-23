    if (reader.HasRows)
    {
        DataTable schemaTable = reader.GetSchemaTable();
        DataTable data = new DataTable();
        while (reader.Read())
        {
            foreach (DataColumn column in schemaTable.Columns)
            {
                var newRow = data.Rows.Add();
                newRow[column] = reader[column.Ordinal];
            }
        }
    }

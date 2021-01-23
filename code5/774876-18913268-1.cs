    List<string> tNames= new List<string>();  // fill it with some table names
    List<string> columnNames = new List<string>() { "special" };
    // ...
    IEnumerable<DataRow> tableRows = con.GetSchema("Tables").AsEnumerable()
      .Where(r => tNames.Contains(r.Field<string>("TABLE_NAME"), StringComparer.OrdinalIgnoreCase));
    foreach (DataRow tableRow in tableRows)
    {
        String database = tableRow.Field<String>("TABLE_CATALOG");
        String schema = tableRow.Field<String>("TABLE_SCHEMA");
        String tableName = tableRow.Field<String>("TABLE_NAME");
        String tableType = tableRow.Field<String>("TABLE_TYPE");
        IEnumerable<DataRow> columns = con.GetSchema("Columns", new[] { database, null, tableName }).AsEnumerable()
            .Where(r => columnNames.Contains(r.Field<string>("COLUMN_NAME"), StringComparer.OrdinalIgnoreCase));
        if (columns.Any())
        {
            tables.Add(tableName);
        }
    }

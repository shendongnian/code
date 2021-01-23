    List<string> tNames= new List<string>();  // fill it with some table names
    // ...
    IEnumerable<DataRow> tables = con.GetSchema("Tables").AsEnumerable()
      .Where(r => tNames.Contains(r.Field<string>("TABLE_NAME"), StringComparer.OrdinalIgnoreCase));
    foreach (DataRow tableRow in tables)
    {
        String database = tableRow.Field<String>("TABLE_CATALOG");
        String schema = tableRow.Field<String>("TABLE_SCHEMA");
        String tableName = tableRow.Field<String>("TABLE_NAME");
        String tableType = tableRow.Field<String>("TABLE_TYPE");
        tables.Add(tableName);
    }

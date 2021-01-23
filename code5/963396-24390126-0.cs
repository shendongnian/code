    var marlin = new Marlin(ClusterCredentials.FromFile("credentials.txt"));
    var tableName = "table";
    var testTableSchema = new TableSchema();
    testTableSchema.name = tableName;
    testTableSchema.columns.Add(new ColumnSchema() { name = "d" });
    testTableSchema.columns.Add(new ColumnSchema() { name = "f" });
    marlin.CreateTable(testTableSchema);

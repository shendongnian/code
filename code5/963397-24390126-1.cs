    var marlin = new Marlin(ClusterCredentials.FromFile("credentials.txt"));
    var testTableSchema = new TableSchema();
    testTableSchema.name = "table";
    testTableSchema.columns.Add(new ColumnSchema() { name = "d" });
    testTableSchema.columns.Add(new ColumnSchema() { name = "f" });
    marlin.CreateTable(testTableSchema);

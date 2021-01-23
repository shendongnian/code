    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    using (var cmd = new SqlCommand("SELECT * FROM dbo.TableName", con))
    {
        con.Open();
        using (var reader = cmd.ExecuteReader())
        using (var schemaTable = reader.GetSchemaTable())
        {
            foreach (DataRow row in schemaTable.Rows)
            {
                string column = row.Field<string>("ColumnName");
                string type = row.Field<string>("DataTypeName");
                int size = row.Field<int>("ColumnSize");
                Console.WriteLine("Column: {0} Type: {1} Size: {2}", column, type, size);
            }
        }
    }

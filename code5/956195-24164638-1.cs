    using (var con = new SqlConnection(Properties.Settings.Default.RM2ConnectionString))
    using (var cmd = new SqlCommand("SELECT * FROM dbo.Test", con))
    {
        con.Open();
        using (var reader = cmd.ExecuteReader())
        using (var schemaTable = reader.GetSchemaTable())
        {
            foreach (DataRow row in schemaTable.Rows)
            {
                string column = row.Field<string>("ColumnName");
                string type = row.Field<string>("DataTypeName");
                short precision = row.Field<short>("NumericPrecision");
                short scale = row.Field<short>("NumericScale");
                Console.WriteLine("Column: {0} Type: {1} Precision: {2} Scale: {3}", column, type, precision, scale);
            }
        }
    }

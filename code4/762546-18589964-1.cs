    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        DataTable table = connection.GetSchema("Tables");
        // displaying data:
        foreach (System.Data.DataRow row in table.Rows)
        {
            foreach (System.Data.DataColumn col in table.Columns)
            {
               Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
            }
    }

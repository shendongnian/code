    // Your array of IDs
    int[] ids = new[] { 1, 2, 3, 4, 5, 6, 7, 10 };
    using (var connection = new SqlConnection("Initial Catalog=AdventureWorksLT2012;Integrated Security=True"))
    {
        connection.Open();
        using (var command = new SqlCommand("SELECT CustomerID FROM SalesLT.Customer WHERE CustomerID IN (SELECT Value FROM @1)", connection))
        {
            // An untyped Datatable
            var dt = new DataTable();
            // With a single column
            dt.Columns.Add();
            // Copy your IDs in the DataTable
            foreach (var v in ids)
            {
                dt.Rows.Add(v);
            }
            // Create the Table-Valued Parameter
            var param = command.Parameters.AddWithValue("@1", dt);
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = "dbo.IntArray";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader[0];
                    Console.WriteLine(id);
                }
            }
        }
    }

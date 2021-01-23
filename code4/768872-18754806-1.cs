    using (var connection = new SqlConnection(connectionString))
    using (var adapter = new SqlDataAdapter(sql, connection))
    {
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine("--- Row ---");
            foreach (var item in row.ItemArray) 
            {
                Console.Write("Item: "); 
                Console.WriteLine(item); 
            }
        }
    }

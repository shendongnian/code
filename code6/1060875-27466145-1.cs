    using (SqlDataAdapter adapter = new SqlDataAdapter(comm))
    {
        adapter.Fill(table);
    }
    foreach(var row in table.Rows)
    {
        Console.WriteLine(String.Join(",", row.ItemArray));
    }
                

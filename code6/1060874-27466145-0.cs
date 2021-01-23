    using (SqlDataAdapter adapter = new SqlDataAdapter(comm))
    {
        adapter.Fill(table);
    }
    for (int i = 0; i < table.Rows.Count; i++)\\Arrays start at 0
    {
        //This will put an extra ',' at the end of the line
        Console.WriteLine(String.Join(",", table.Rows[i].ItemArray));
    }    
                

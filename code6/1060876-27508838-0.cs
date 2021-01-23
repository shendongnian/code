    {
    adapter.Fill(table);
    }
    foreach (DataRow row in table.Rows)
    {
    Console.WriteLine(String.Join(",", row.ItemArray));
    }

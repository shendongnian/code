    foreach (DataRow row in table.Rows) // Loop over the rows.
    {
        int j = 0;
        foreach (var item in row.ItemArrai) // Loop over the items.
        {
            j++;
            for (int i = 1; i < 30; i++)
            {
                excell_app.createHeaders(1, 1, "" + item + "", i, i, 1, "black", false, 10, "n");
            }
        }
        
        Console.WriteLine(j);
    }

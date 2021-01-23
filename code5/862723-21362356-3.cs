    foreach (DataRow row in table.Rows) // Loop over the rows.
    {
        int i = 0;
        foreach (var item in row.ItemArray) // Loop over the items.
        {
            i++;
            for (int j = 1; j < 30; j++)
            {
                excell_app.createHeaders(1, 1, "" + item + "", j, j, 1, "black", false, 10, "n");
            }
        }
        
        Console.WriteLine(i);
    }

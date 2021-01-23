    foreach (DataRow row in table.Rows) // Loop over the rows.
    {
        foreach (var item in row.ItemArray) // Loop over the items.
        {
            for (int i = 1; i < row.ItemArray.Count; i++)
            {
                excell_app.createHeaders(1, 1, "" + item + "", i, i, 1, "black", false, 10, "n");
            }
        }
    }

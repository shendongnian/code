    for (int i = 0; i < hlist.Count; i += 2)
    {
        TableRow row = new TableRow(); // Create the new rows
        table.Rows.Add(row);
        for (int j = i; j < Math.Min(i + 2, hlist.Count); j++)
        {
            TableCell cell = new TableCell();
            cell.Controls.Add(hlist[j]);
            row.Controls.Add(cell);
        }
    }

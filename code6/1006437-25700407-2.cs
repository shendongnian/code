    int r = 0;
    while (r < GridView.Rows.Count)
    {
        Console.WriteLine(GridView.Rows[r].Cells[0].Value.ToString());
        r++;
    }
    return;

    int colIndex = GridView1.Columns.Cast<DataControlField>()
        .Select((col, index) => new{ col, index })
        .Where(x => x.col.HeaderText.Equals("Site_name", StringComparison.InvariantCultureIgnoreCase))
        .Select(x => x.index).First();
    GridView1.Columns[colIndex].Visible = isColumnVisible; // acc. to your logic

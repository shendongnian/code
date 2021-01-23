    var blanks = GridView1.Rows
        .Where( e => string.IsNullOrEmpty(e.Cells[6].Text))
        .Select(e => e.RowIndex);
    foreach(var blank in blanks)
        GridView1.DeleteRow(blank);

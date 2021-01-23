    var start = new DateTime(2012, 5, 10);
    var end = DateTime.Now;
    int i = 0;
    for (var dt = start; dt <= end; dt = dt.AddDays(7))
    {
        dataGridView1.Columns.Add(new DataGridViewColumn
        {
            HeaderText = (++i).ToString(),
            CellTemplate = new DataGridViewTextBoxCell()
        });
    }

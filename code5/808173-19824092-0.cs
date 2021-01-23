    for (int i = 0; i < 5; i++)
    {
        DateTime dt = DateTime.Now;
        dataGridView1.Columns[0].DataGridView.Rows.Add(dt);
        dataGridView1.Columns[0].DefaultCellStyle.Format = "T";
        foreach (DataGridViewColumn column in dataGridView1.Columns)
        {
           column.DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }

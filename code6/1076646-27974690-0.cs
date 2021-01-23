    DataGridView dataGridView2 = new DataGridView();
    foreach(DataGridViewRow row in dataGridView1.Rows)
    {
        DataGridViewRow newRow = (DataGridViewRow)row.Clone();
        for (int i = 0; i < row.Cells.Count; i++)
        {
            newRow.Cells[i].Value = row.Cells[i].Value;
        }
        dataGridView2.Rows.Add(newRow);
    }

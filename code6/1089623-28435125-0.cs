    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        foreach (DataGridViewColumn column in dataGridView1.Columns)
            column.MinimumWidth = column.Width;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

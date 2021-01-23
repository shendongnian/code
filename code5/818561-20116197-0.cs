    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell curCell = dataGridView1[e.ColumnIndex, e.RowIndex];
    }
    
    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        MouseButtons curButton = e.Button;
    }

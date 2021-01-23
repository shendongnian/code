    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == yourLastColumnIndex)
        {
            if (e.KeyCode == Keys.Tab)
            {
                dataGridView1.Rows.Add();
            }
        }
    }

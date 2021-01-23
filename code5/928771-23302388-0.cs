    private void dataGridView1_CellMouseClick(Object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex != -1)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        else
        {
            textBox1.Text = "";
        }
    }

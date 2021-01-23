    private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex != -1)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString() == "Error")
            {
                e.CellStyle.BackColor = Color.Red;
            }
            else if (dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString() == "NoError")
            {
                 e.CellStyle.BackColor = Color.Green;
            }
        }
    }

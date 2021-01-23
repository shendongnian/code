    private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex != -1 && e.ColumnIndex == 7)
        {
            if (e.Value.ToString() == "Error")
            {
                e.CellStyle.BackColor = Color.Red;
            }
            else if (e.Value.ToString() == "NoError")
            {
                 e.CellStyle.BackColor = Color.Green;
            }
        }
    }

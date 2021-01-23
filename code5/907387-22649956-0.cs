    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 3 && e.Value == targetValue)
            e.CellStyle.BackColor = Color.Red;
        else
            e.CellStyle.BackColor = SystemColors.Window;
    }

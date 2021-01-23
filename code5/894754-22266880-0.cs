    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == ColumnIndex)
        {
            e.Value = // formatted value
            e.FormattingApplied = true;
        }
    }

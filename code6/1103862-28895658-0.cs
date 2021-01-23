    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Value as string))
        {
            e.Value = "NULL";
            e.FormattingApplied = true;
        }
    }

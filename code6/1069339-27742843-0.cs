    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "Value")
        {
            if (e.Value != null)
            {
                int intValue = (int)e.Value;
                e.Value = (intValue == 0) ? "NO" : "YES";
            }
        }
    }

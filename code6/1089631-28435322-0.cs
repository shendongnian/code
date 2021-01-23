    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == columnAuth.Index)
        {
            if (e.Value == "1")
            {
                e.Value = "SuperAdmin";
                e.FormattingApplied = true;
            }
            else if (e.Value == "2")
            {
                e.Value = "Admin";
                e.FormattingApplied = true;
            }
            else if (e.Value == "3")
            {
                e.Value = "User";
                e.FormattingApplied = true;
            }
        }
    }

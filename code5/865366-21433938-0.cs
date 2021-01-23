    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.Value != null)
            {
                int val;
                if (int.TryParse(e.Value.ToString(), out val) && val < 0)
                {
                    e.Value = "N/A";
                    e.FormattingApplied = true;
                }
            }
        }

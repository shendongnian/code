    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() == "Special")
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }

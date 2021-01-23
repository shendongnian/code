    void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
    for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
            if (dataGridView4.Rows[i].Cells["cellname"].Value != null)
            {
                if ((int)dataGridView4.Rows[i].Cells["cellname"].Value <=35)
                {
                    dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }

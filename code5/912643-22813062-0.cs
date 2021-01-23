    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if(dataGridView1.Rows[e.RowIndex].Cells["Validated"].Value.ToString() == "Y")
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = System.Drawing.Color.LightGray;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle = style;
                }
    }

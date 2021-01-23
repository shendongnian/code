    private void gridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        for (int y = 0; y < unreadList.Count; y++)
        {
            if (unreadList[y] == 1)
                dataGridView1.Rows[y].DefaultCellStyle.BackColor = Color.LightPink;
        }
    }
    private void gridItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.CellStyle.BackColor != Color.LightPink) //This will color every other row green - as an example.
            e.CellStyle.BackColor = Color.LightGreen;
    }

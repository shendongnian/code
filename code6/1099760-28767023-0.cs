    private ToolTip toolTip;
    
    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
        var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                
        if (cell.Value != null){
            toolTip = new ToolTip();
            toolTip.InitialDelay = 3000;
            dataGridView1.ShowCellToolTips = false;
            toolTip.SetToolTip(dataGridView1, cell.Value.ToString());
        }    
    }
                
    private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
    {
         if (toolTip != null)
             toolTip.Dispose();
    }

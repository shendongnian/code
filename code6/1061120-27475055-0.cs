    foreach (DataGridViewRow row in dgv_All.Rows)
    {
        string RowType = row.Cells[0].Value.ToString();
     
        if (RowType == "Type A")
        {
            row.DefaultCellStyle.BackColor = Color.Red;
            row.DefaultCellStyle.ForeColor = Color.White;
        }
        else if (RowType == "Type B")
        {
            row.DefaultCellStyle.BackColor = Color.Yellow;
            row.DefaultCellStyle.ForeColor = Color.Black;
        }
    }
      
         

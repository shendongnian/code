    foreach (DataGridViewRow row in mydataGridView.Rows)
    {
        string RowType = row.Cells[0].Value.ToString();
     
        if (RowType == "Some Value")
        {
            row.DefaultCellStyle.BackColor = Color.Green;
            row.DefaultCellStyle.ForeColor = Color.Green;
        }
    }

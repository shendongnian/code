     private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        if (e.RowIndex == 1)
        {
            DataGridViewCell cell=dataGridView1.Rows[e.RowIndex].Cells[0];
            DataGridViewCheckBoxCell chkCell = cell as DataGridViewCheckBoxCell;
            chkCell.Value = false;
            chkCell.FlatStyle = FlatStyle.Flat;
            chkCell.Style.ForeColor = Color.DarkGray;
            cell.ReadOnly = true;
        }
    }

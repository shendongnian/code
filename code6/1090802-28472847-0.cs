    if(GridView1.Rows.Count > 0 )
    {
    foreach (GridViewRow row in GridView1.Rows)
    {
        if (row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkRow = (row.Cells[0].FindControl("Transfer_Selector") as CheckBox);
            if (chkRow.Checked)
            {
                //do something
            }
        }
    }
    }

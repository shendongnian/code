    protected void grdMyList_RowDataBound(object sender, GridViewEventsArgs e)
    {
        DataRow row = (DataRow)e.Row.DataItem;
        e.Row.Cells[0].BackColor = System.Drawing.Color.FromName(row["Color"].ToString());
    }

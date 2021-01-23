    protected void grdMyList_RowDataBound(object sender, GridViewEventsArgs e)
    {
        DataTable dtMyList = (DataTable)ViewState["MyList"];
    
        index i = e.Row.RowIndex;
        e.Row.Cells[0].BackColor = System.Drawing.Color.FromName(Convert.ToString(dtMyList.Rows[i]["Color"]));
    }

    protected void grv_taskfilter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false; 
            e.Row.Cells[1].Visible = false; 
            e.Row.Cells[2].Visible = false;  
        }
    }

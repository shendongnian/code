    protected void grvF2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row as GridViewRow;
        if (gvr != null && gvr.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb = gvr.Cells[1].Controls[0] as LinkButton;
            if (lb != null && gvr.Cells[0].Text.ToLower() != "something")
            {
                lb.Visible = false;
            }
        }
               
    }

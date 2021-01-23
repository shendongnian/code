    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
             TextBox txtNewId = (TextBox)e.Row.FindControl("txtNewId");
             txtNewId.Text = "New 01";
        }
    }

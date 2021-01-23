    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == DataControlRowState.Alternate)
        {
           //on you condition
            TextBox txt = (TextBox)e.Row.FindControl("ControlID");
            txt.ReadOnly = true;
        }
    }

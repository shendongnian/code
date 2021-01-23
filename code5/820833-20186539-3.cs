    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
     GridViewRow grd = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
     int rowindex = grd.RowIndex;
     CheckBox chkbox = (CheckBox)grd.Rows[rowindex].FindControl("checkboxId"); 
    // do whatever
    }

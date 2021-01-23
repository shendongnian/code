    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Register")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int courseId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
            //your other codes
        }

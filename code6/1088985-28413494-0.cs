    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)((ImageButton)sender).NamingContainer;
        Int32 UserId = Convert.ToInt32(gvUsers.DataKeys[gvRow.RowIndex].Value);
        // delete and hide the row from grid view
        if (DeleteUserByID(UserId))
            gvRow.Visible = false;
    }

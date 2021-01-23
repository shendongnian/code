    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lblid = (Label)row.FindControl("Elblid");
        TextBox txtuser = (TextBox)row.FindControl("EtxtUserName");
        TextBox txtpass = (TextBox)row.FindControl("EPassword");
    }
    

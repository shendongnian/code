    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtBranch (TextBox)e.Row.FindControl("txtBranch"); 
            txtBranch.Text = lbl_sal.Text;
        }
    }

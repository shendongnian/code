    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Label label = (Label)this.GridView1.Rows[e.NewEditIndex].FindControl("Label4");
        string value = label.Text;
    }

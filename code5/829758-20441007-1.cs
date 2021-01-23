    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
     GridView1.EditIndex = e.NewEditIndex;
     bindgrid(); // your GV bind function
    }
    
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
       GridView1.EditIndex = -1;
       bindgrid();// your GV bind function
    } 

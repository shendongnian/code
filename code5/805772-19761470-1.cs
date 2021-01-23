    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit") 
        {
            // Get the actual row
            GridViewRow theGridViewRow = GridView1.Rows(e.RowIndex);
            // Do something with grid view row here
        }
    }

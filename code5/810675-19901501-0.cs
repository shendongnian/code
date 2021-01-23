    protected void btnSave_Click(object sender, CommandEventArgs e)
    {
        if(e.CommandArgument == "Add")
        {
            //do save logic here
            btnSave.Text = "Add done";
        }
        if(e.CommandArgument == "Edit")
        {
            //do update logic here
            btnUpdate.Text = "Update done";
        }            
    }

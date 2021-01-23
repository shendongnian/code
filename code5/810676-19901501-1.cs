    protected void btnSave_Click(object sender, CommandEventArgs e)
    {
        if(string.Equals(e.CommandArgument,"Add"))
            {
                //do save logic here
                btnSave.CommandArgument = "Edit";
                btnSave.Text = "Update";
            }
            if (string.Equals(e.CommandArgument, "Edit"))
            {
                //do update logic here
                btnSave.Text = "Update done";
            }   
    }

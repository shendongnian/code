    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    if (e.CommandName == "Action")
    {
    string ID = e.CommandArgument; // Do something with it. 
    }

    protected void dg_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName =="del")
        {
            //Delete Records
           LoadData();
        }
    
    }
    
    public void dg_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        LoadData();
    } 

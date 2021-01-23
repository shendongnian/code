    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
    TextBox txtMoratoriumPeroid= row.FindControl("txtMoratoriumPeroid") as TextBox;
    if(txtMoratoriumPeroid != null)
    {
        //Your code here.
        string txtMoratoriumPeroidText =  txtMoratoriumPeroid.Text; 
    }

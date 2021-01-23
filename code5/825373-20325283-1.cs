    protected void gridItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddToCart")
        {
            // Retrieve the row index stored in the 
            // CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);
    
            // Retrieve the row that contains the button 
            // from the Rows collection.
            GridViewRow row = this.gridItems.Rows[index];
    
    	    //get key setting in DataKeyNames
            string id = gridItems.DataKeys[index].Value.ToString();
    
    	    //get value from Controls in ItemTemplate
            string name = ((Label)(row.FindControl("lblName"))).Text;
            string category = ((Label)(row.FindControl("lblCategory"))).Text;
            string cantidad = ((TextBox)(row.FindControl("txtCant"))).Text;
                
        }
    }

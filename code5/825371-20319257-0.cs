    //get row
    GridViewRow gvr = ((GridViewRow)(((Button)e.CommandSource).NamingContainer));
    
    //get datakey
    string id = gridItems.DataKeys[Convert.ToInt32(gvr.RowIndex)].Value.ToString();
    
    //get field value
    string name = ((Label)(gvr.FindControl("lblName"))).Text;
    string category = ((Label)(gvr.FindControl("lblCategory"))).Text;
    string cantidad = ((TextBox)(gvr.FindControl("txtCant"))).Text;

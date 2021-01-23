    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowID = Convert.ToInt32(gvProduct.DataKeys[Row.RowIndex].Value);
    
            if (e.CommandName == "EditCommand")
            {
                EditFunction(rowID);
            }
            else
                if (e.CommandName == "DeleteCommand")
                {
                    DeleteFunction(rowID);
                }
        }

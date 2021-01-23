    protected void GridViewPurchaseReturn_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       //Your code to delete the records in db        
        BindReturnGrid();
    }
 
    protected void GridViewPurchaseReturn_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Your code to update the records in db
        GridViewPurchaseReturn.EditIndex = -1;
        BindReturnGrid();
    }

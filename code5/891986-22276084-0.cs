    protected void gridLoc_InsertCommand(object sender, GridCommandEventArgs e)
     {
        GridEditFormInsertItem insertItem = (GridEditFormInsertItem)e.Item;
        TextBox txtLocName= insertItem.FindControl("txtLocName") as TextBox;
        locBLL.InsertLoc(txtLocName.Text, false);
        // close the insert form
        e.Canceled = true;
        gridLoc.MasterTableView.IsItemInserted = false;
        gridLoc.MasterTableView.Rebind();    
    }

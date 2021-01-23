    protected void CheckChanged(Object sender, System.EventArgs e)
    {
        // Do your stuff here
    }
    
    private void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            CheckBox box = (CheckBox)item.FindControl("cbChecked");
    	
           //store into Database fetching the text/value of the check box.
        }
    }

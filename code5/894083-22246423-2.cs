    protected void dlPro_Details_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    	if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		var innerDL = e.Item.FindControl("dlFeatures") as DataList;
    		if(innerDL != null)
    		{
    			//do something
    		}
    	}
    }

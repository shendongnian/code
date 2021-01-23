    protected void dlPro_Details_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    	if(e.Item.ItemType == ItemType.Item || e.Item.ItemType == ItemType.AlternatingItem)
    	{
    		var innerDL = e.Item.FindControl("dlFeatures") as DataList;
    		if(innerDL != null)
    		{
    			//do something
    		}
    	}
    }

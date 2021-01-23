    void rptAdditionalCosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Footer)
    	{
    		if (optionalVisible && additionalVisible)
    			e.Item.Visible = false;
    	}
    }
    
    void rptOptionalExtras_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Header)
    	{
    		if (optionalVisible && additionalVisible)
    			e.Item.Visible = false;
    	}
    }

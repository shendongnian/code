    public void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs  e)
    {
    	if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {	
    		GridView gvProduct = (GridView)e.Item.FindControl("gvProduct");
    		DataRowView drv = (DataRowView)e.Item.DataItem;
            gvProduct.DataSource = drv[prodList[i].id];
    		gvProduct.DataBind();
    	}
    }

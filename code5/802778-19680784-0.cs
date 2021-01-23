    protected override void OnItemCreated(RepeaterItemEventArgs e)
    		{
    			base.OnItemCreated(e);
    
    			if (e.Item.DataItem != null && (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem))
    			{
    				DataRowView dt = (DataRowView)e.Item.DataItem;
    				if (dt.DataView.Table.Columns["IsHeading"] != null)
    				{
    					if ((dt["IsHeading"].ToString()) == "true")
    					{
    						ItemHeaderContainer container = new ItemHeaderContainer();
    						ItemHeaderTemplate.InstantiateIn(container);
    
    						container.DataItem = e.Item.DataItem;
    						container.DataBind();
    					}
    				}
    			}
    		}

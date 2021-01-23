    public void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs  e)
    {
    	if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
    		Repeater Repeater2 = (Repeater)e.Item.FindControl("Repeater2");
    		Repeater2.DataSource = GetDataFromSomeSource();
    		Repeater2.DataBind(); //This will invoke the child repeater of Repeater1's ItemDataBound event
        }
    }

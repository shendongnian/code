    protected void Repeater1_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DropDownList ddldrop = (DropDownList) e.Item.FindControl("DropDownList1");
            // here you are
        }
    }

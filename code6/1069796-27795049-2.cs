    protected void Category_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Category ct = (Category)e.Item.DataItem;
            DropDownList ddl = (DropDownList)e.Item.FindControl("Active");
            ddl.SelectedValue = ct.ActiveID.ToString(); // I don't know if this is the right property. 
        }
    }

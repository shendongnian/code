    protected void Category_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRow dr = (DataRow)e.Item.DataItem;
            DropDownList ddl = (DropDownList)e.Item.FindControl("Active");
            ddl.SelectedValue = dr["Field"].ToString();
        }
    }

    protected void ListView1_ItemDataBound(Object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            DropDownList ddlItem = (DropDownList) e.Item.FindControl("ddlItem");
            var rowView = e.Item.DataItem as DataRowView;
            int id = (int)rowView["ID"];  // whatever
            // get data from id ...
            //ddlItem.DataSouce = data;
            //ddlItem.DataTextField = "Name";
            //ddlItem.DataValueField = "ID";
            //ddlItem.DataBind();
        }
    }

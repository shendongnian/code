    protected void Product_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // presuming the source of the repeater is a DataTable:
            DataRowView rv = (DataRowView) e.Item.DataItem;
            string field4 = rv.Row.Field<string>(3); // presuming the type of it is string
            // ...
        }
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            GridCommandItem commandItem = (GridCommandItem)e.Item;
            RadComboBox combo = (RadComboBox)commandItem.FindControl("MethodRadComboBox");
            combo.DataSource = e.Item.OwnerTableView.DataSource;
            combo.DataBind();

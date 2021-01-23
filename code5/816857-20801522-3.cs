     protected void RadWages_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridHeaderItem)
        {
            GridHeaderItem hItem = (GridHeaderItem)e.Item;
            CheckBox chk1 = (CheckBox)hItem.FindControl("chkall");
            HiddenField1.Value = chk1.ClientID.ToString();
        }
    }

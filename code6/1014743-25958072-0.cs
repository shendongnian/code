    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            GridEditFormItem item = e.Item as GridEditFormItem;
            TextBox txt_lect_in = item.FindControl("txt_lect_in") as TextBox;
            //Access your textbox heer
        }
    }
    //OR
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            GridEditFormItem item = e.Item as GridEditFormItem;
            TextBox txt_lect_in = item.FindControl("txt_lect_in") as TextBox;
            //Access your textbox heer
        }
    }

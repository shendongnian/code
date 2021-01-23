    protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            GridEditFormItem editItem = (GridEditFormItem)e.Item;
            // Use the column's unique name as the accessor:
            DropDownList list = (DropDownList)editItem["RowId"].Controls[0];
            list.SelectedValue = HiddenFieldIdToSave.Value;
        }
    }

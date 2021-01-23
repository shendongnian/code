    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            TextBox txtBox = (TextBox)item["Name"].Controls[0];
            (txtBox.Parent.Parent.Controls[0] as TableCell).Text = (txtBox.Parent.Parent.Controls[0] as TableCell).Text.Replace("Name:", "yourtext:");
        }
    }

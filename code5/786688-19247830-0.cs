    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            // assuming you have an ItemTemplate with a label where you want to show this
            Label lblInfo = (Label) e.Item.FindControl("LblInfo");
            DataRowView rowView = (DataRowView)e.Item.DataItem;
            if (rowView.Row.Table.Columns.Contains("Phone"))
            {
                lblInfo.Text = "we have the phone property";
            }
            else
            {
                lblInfo.Text = "no phone available";
            }
        }
    }

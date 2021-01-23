    void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label TitleLabel = (Label)e.Item.FindControl("TitleLabel");
            TitleLabel.Text = "changed by code";
        }
    }

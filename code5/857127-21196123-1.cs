    protected void DataListAnnouncements_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem||
             e.Item.ItemType == ListItemType.SelectedItem
            )
        {
            // Here BackColor - Grey: WasRead; Yellow: Unread
            var wasRead = ((DashBoardView)e.Item.DataItem).WasRead;
            e.Item.BackColor = wasRead? System.Drawing.Color.Gray: System.Drawing.Color.Yellow;
    
        }
    
    }

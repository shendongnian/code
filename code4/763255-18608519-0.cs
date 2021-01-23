    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                int index = e.Item.DisplayIndex;
                if(index==2)
     
                e.Item.Visible = false;
            }
        }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
           Button hiddenButton=(Button) dataItem.FindControl("hiddenButton");
           hiddenButton.Visible = false;           
    
        }
    
    }

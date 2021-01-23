     protected void lvDetects_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
     if (e.Item.ItemType == ListViewItemType.DataItem)
     {
          System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
          string yourDate = rowView["sDate"].ToString(); // you can check your sDate is null or not
          
     }
    }

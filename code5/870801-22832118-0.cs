    private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       foreach (var item in e.AddedItems)
         {
           if (!item.IsBad())
           {
             ItemList.SelectedItems.Remove(item);
           }
           else
           {
             isBadAdd = true;
           }
         }
    }

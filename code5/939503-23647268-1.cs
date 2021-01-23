    private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
         if (e.AddedItems.Count > 0)
         {
            YourListItemObject item = e.AddedItems[0] as YourListItemObject;
            YourMainList.Remove(item);
         }
        
    }

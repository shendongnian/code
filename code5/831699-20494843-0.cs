    private void cmdCollapse_Click(object sender, RoutedEventArgs e)
     {
      foreach (TreeViewItem item in treeview.Items)
       CollpaseTreeviewItems(item);
    
      
      }
    
    void CollapseTreeviewItems(TreeViewItem Item)
      {
       Item.IsExpanded = false;
    
       foreach (TreeViewItem item in Item.Items)
       {
        item.IsExpanded = false;
    
        if (item.HasItems)
         CollapseTreeviewItems(item);
       }

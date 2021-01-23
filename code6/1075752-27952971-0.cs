    private void SdxGridView_GotFocus(object sender, RoutedEventArgs e)
    {
      if (e.OriginalSource is GridViewItem && !((GridViewItem)e.OriginalSource).IsSelected)
      {
        SelectedItems.Clear();
        ((GridViewItem)e.OriginalSource).IsSelected = true;
      }
    }

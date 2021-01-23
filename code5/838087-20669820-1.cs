    private void itemsListBoxRightTapped( object sender, RightTappedRoutedEventArgs e )
    {
      Border clickBorder = e.OriginalSource as Border;
      if ( clickBorder != null )
      {
         MyItemType selectedItem = clickBorder.DataContext as MyItemType;
       ...

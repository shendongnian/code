    private void LLS_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (LLS.SelectedItem != null)
      {
         ShoppingList item = LLS.SelectedItem as ShoppingList;
         TextBlock.Text = item.yourProperty;
      }
    }

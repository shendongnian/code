    public void dataGridCell_GotFocus(object sender, RoutedEventArgs e)
    {
      if (e.OriginalSource is CheckBox)
      {
        // checkbox was clicked
      }
      else if (e.OriginalSource is DataGridCell)
      {
        // somwhere outside the checkbox was clicked
      }
    }

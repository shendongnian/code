    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
      string selection = (string)FilePathBox.SelectedItem;
      DataContext = OldNewService.ReadFile(selection);
    }
 

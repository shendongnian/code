    void handleButtonClick(object sender, RoutedEventArgs e)
    {
      var button = (Button)sender;
      int row = Grid.GetRow(button);
      int column = Grid.GetColumn(button);
    
      // Do what ever you would like to do...
    }

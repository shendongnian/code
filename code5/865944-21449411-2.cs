    private void MyButton_Click(object sender, RoutedEventArgs e)
      {
        var isStarted = ViewModel.IsProcessStart;
        ViewModel.IsProcessStart = !isStarted;
      }

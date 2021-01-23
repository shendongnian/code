    private async void button1_Click(object sender, RoutedEventArgs e) {
      button1.IsEnabled = false;
      await AddLabels();
      button1.IsEnabled = true;
    }
    
    private async Task AddLabels() {
      for (int i = 0; i < 10; ++i) {
        Label lb = new Label { Content = await DataSupplier.GenerateRandomInt() };
        stackPanel1.Children.Add(lb);
      }
    }

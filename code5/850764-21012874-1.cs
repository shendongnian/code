    private float buyCounter = 0;
    private void RepeatButton_Click(object sender, RoutedEventArgs e) {
      buyCounter += 1;
      buyClickerButtonCost.Text = buyCounter.ToString();
    }

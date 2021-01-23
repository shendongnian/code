    private async void button_Click(object sender, RoutedEventArgs e)
    {
        await Task.WhenAll(
            PopulateNameAsync(),
            PopulateCityAsync(),
            PopulateRankAsync());
    }
    private async Task PopulateNameAsync()
    {
        nameTextBox.Text = await GetNameAsync();
    }
    private async Task PopulateCityAsync()
    {
        cityTextBox.Text = await GetCityAsync();
    }
    private async Task PopulateRankAsync()
    {
        rankTextBox.Text = await GetRankAsync();
    }

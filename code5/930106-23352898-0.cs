    private async void button_Click(object sender, RoutedEventArgs e)
    {
        var results = await Task.WhenAll(
            GetNameAsync(),
            GetCityAsync(),
            GetRankAsync()
        );
    
        nameTextBox.Text = results[0];
        nameCityBox.Text = results[1];
        nameRankBox.Text = results[2];
    }

    private async void button_Click(object sender, RoutedEventArgs e)
    {
        TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        await Task.WhenAll(
            GetNameAsync().ContinueWith(nameTask => { nameTextBox.Text = nameTask.Result; }, uiScheduler),
            GetCityAsync().ContinueWith(cityTask => { cityTextBox.Text = cityTask.Result; }, uiScheduler),
            GetRankAsync().ContinueWith(rankTask => { rankTextBox.Text = rankTask.Result; }, uiScheduler));
    }

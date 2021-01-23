    public static Task WhenAllTasks(params Func<Task>[] taskProducers)
    {
        return Task.WhenAll(taskProducers.Select(taskProducer => taskProducer()));
    }
    private async void button_Click(object sender, RoutedEventArgs e)
    {
        await WhenAllTasks(
            async () => nameTextBox.Text = await GetNameAsync(),
            async () => cityTextBox.Text = await GetCityAsync(),
            async () => rankTextBox.Text = await GetRankAsync());
    }

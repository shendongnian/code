    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 2000; i++)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            labelName.Content = i.ToString();
        }
    }

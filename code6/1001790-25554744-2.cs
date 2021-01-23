    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await DoWorkAsync();
        // Do more stuff here
    }
    private Task DoWorkAsync()
    {
        return Task.Delay(2000); // Fake work.
    }

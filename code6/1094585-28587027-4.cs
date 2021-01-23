    private async void Button2_Click(object sender, RoutedEventArgs e)
    {
        var task = Task.FromResult(false);
        Console.WriteLine("1");
        var result = await task;
        await InnerTask(result);
        Console.WriteLine("4");
    }

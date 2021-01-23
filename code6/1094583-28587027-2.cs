    private async void Button2_Click(object sender, RoutedEventArgs e)
    {
        var task = Task.FromResult(false);
        var result = await task;
        Console.WriteLine("1");
        await InnerTask(result);
        Console.WriteLine("4");
    }

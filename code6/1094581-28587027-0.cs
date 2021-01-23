    private async void Button2_Click(object sender, RoutedEventArgs e)
    {
        var task = Task.FromResult(false);
        Task aggregatedTask = task.ContinueWith(task1 => InnerTask(task1.Result)).Unwrap();
        Console.WriteLine("1");
        await aggregatedTask;
        Console.WriteLine("4");
    }

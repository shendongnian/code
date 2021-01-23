    private async void StartBtn_Click(object sender, RoutedEventArgs e)
    {
        var progress = new Progress<double>( (p) =>
            {
                progresPB.Value = p;
            });
        await DoSomething(progress); // start asynchronously Task with progress indication
    }
    private Task<bool> DoSomething(IProgress<double> progress)
    {
        TaskCompletionSource<bool> taskComplete = new TaskCompletionSource<bool>();
        // run your heavy task asynchronous
        Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++) // work divided into parts
                {
                    await Task.Delay(1000);    // some heavy work 
                    progress.Report((double)i / 10);
                }
                taskComplete.TrySetResult(true);
            });
        return taskComplete.Task;
    }

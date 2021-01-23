    private static async void Async()
    {
        Task taskDelay1 = Task.Run(() => Task.Delay(1000))
                          .ContinueWith(x => Dispatcher.Invoke(() => this.label1.Content = "One done"));
        Task taskDelay2 = Task.Run(() => Task.Delay(1500))
                          .ContinueWith(x => Dispatcher.Invoke(() => this.label2.Content = "Two done"));
        Task taskDelay3 = Task.Run(() => Task.Delay(2000))
                          .ContinueWith(x => Dispatcher.Invoke(() => this.label3.Content = "Three done"));
        await Task.WhenAll(taskDelay1, taskDelay2, taskDelay3);
    }

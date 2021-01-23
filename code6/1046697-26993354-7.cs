    async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        await DoWork();
    }
    async Task DoWork()
    {
        await Task.Run(async () =>
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                await Progress.Dispatcher.BeginInvoke(new Action(delegate() { ++Progress.Value; }), null);
            }
        });
    }

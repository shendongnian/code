    async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i <= 100; i++)
        {
            Thread.Sleep(100);
            Progress.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Render, new Action(delegate() { ++Progress.Value; }));
            await System.Threading.Tasks.Task.Delay(1);
        }
    }

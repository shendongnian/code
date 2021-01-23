    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        Task.Factory.StartNew(() =>
        {
            Console.Write("test");
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                txt.Text = "Testing";
            }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        });                      
    }

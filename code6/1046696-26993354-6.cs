    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem( (o) =>
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                Progress.Dispatcher.BeginInvoke(new Action(delegate() { ++Progress.Value; }), null);
            }
        });
    }

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);                    
                Progress.Dispatcher.BeginInvoke(new Action(delegate() { ++Progress.Value; }), null);
            }
        });
    }

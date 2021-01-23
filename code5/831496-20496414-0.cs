    private void ShowWhiteScreen()
    {
        Dispatcher.Invoke(() =>
        {
            gridWhite.Visibility = System.Windows.Visibility.Visible;
            Timer t = new Timer(1000);
            t.AutoReset = false;
            t.Elapsed += (s, e) =>
            {
                ((Timer)s).Stop();
                ((Timer)s).Dispose();
                Dispatcher.Invoke(() =>
                {
                    gridWhite.Visibility = System.Windows.Visibility.Collapsed;
                });
            };
            t.Start();
        });
    }

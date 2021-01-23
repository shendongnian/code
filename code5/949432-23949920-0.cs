    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        DispatcherTimer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (i, j) => { txtBlock.Text = sw.Elapsed.ToString(); };
        timer.Start();    
    }

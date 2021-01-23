    private void TestBtn_Click(object sender, RoutedEventArgs e)
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };
        DispatcherTimer timer2 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(4) };
        timer1.Tick += async (s1, e1) => { timer1.Stop(); await new MessageDialog("First").ShowAsync(); };
        timer2.Tick += async (s2, e2) => { timer2.Stop(); await new MessageDialog("Second").ShowAsync(); };
        timer1.Start(); timer2.Start();
    }

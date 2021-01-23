     private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void  timer_Tick(object sender, object e)
        {
           // show your message here..
        }

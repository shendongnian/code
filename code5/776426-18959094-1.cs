    private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._timer = new DispatcherTimer();
            this._timer.Interval = TimeSpan.FromMilliseconds(1);
            this._timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }
    void _timer_Tick(object sender, EventArgs e)
    {
        t= t.Add(TimeSpan.FromMilliseconds(1));
        textBox.Text = t.Hours + ":" + t.Minutes + ":" + t.Seconds + ":" + t.Milliseconds;
    }

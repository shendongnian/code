    private void dispatcherTimer_tick(object sender, EventArgs e)
    {
        TimerBlock.Content = (DateTime.Now - started).ToString("hh\\:mm");
        ...
    }

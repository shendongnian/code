    void func()
    {
        StoryBoard myStoryBoard;
        //configure it
        myStoryBoard.Begin();
        DispatcherTimer _timer = new DispatcherTimer();
        _timer.Interval = new TimeSpan(0,0,1);
        _timer.Tick += _timer_Tick;
        _timer.Start();
    }
    void _timer_Tick(object sender, EventArgs e)
    {
        yourTextBlock.Text = "changedText";
        (sender as DispatcherTimer).Stop();
    }

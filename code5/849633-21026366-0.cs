    private DispatcherTimer playTimer;
    public FirstLook()
    {
        this.playTimer = new DispatcherTimer();
        this.playTimer.Interval = TimeSpan.FromSeconds(2);
        this.playTimer.Tick += this.OnPlayTimerTick;
    }
    private void OnPlayTimerTick(object sender, EventArgs e)
    {
        this.slideView.MoveToNextItem();
    }
    private void OnPlayTap(object sender, GestureEventArgs e)
    {
        if (this.playTimer.IsEnabled)
        {
            this.StopSlideShow();
        }
        else
        {
            this.playTimer.Start();
            this.buttonImage.Source = new BitmapImage(new Uri("Images/pause.png", UriKind.RelativeOrAbsolute));
        }
    }
    private void StopSlideShow()
    {
        this.playTimer.Stop();
        this.buttonImage.Source = new BitmapImage(new Uri("Images/play.png", UriKind.RelativeOrAbsolute));
    }

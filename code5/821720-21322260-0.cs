    // In the class members area
    private DispatcherTimer _timer = null;
    
    // In your constructor/loaded method
    _timer = new DispatcherTimer();
    _timer.Interval = TimeSpan.FromMilliseconds(500);
    _timer.Tick += _timer_tick;
    
    // Timer's tick method
    void _timer_tick(object sender, EventArgs e)
    {
      // Convert duration to an integer percentage based on current position of
      //   playback and update the slider control
      TimeSpan ts = meMedia1.NaturalDuration.TimeSpan;
      int percent = int( meMedia1.Position / ts.Seconds * 100 );
      mySliderControl.Value = percent;
    }

    DispatcherTime _blinkTimer = new DispatcherTimer();
    public void StartBlinking() {
      _blinkTimer.Interval = TimeSpan.FromSeconds(1);
      _blinkTimer.Elapsed += ToggleIconVisibility;
      _blinkTimer.Start();
    }
    public void StopBlinking() {
      _blinkTimer.Stop();
      _blinkTimer.Elapsed -= ToggleIconVisibility;
    }
    private void ToggleIconVisibility(object sender, EventArgs e)
    {
      imgstop.Visibility = !imgstop.Visibility;
    } 
 

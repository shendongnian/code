    private DateTime _StartTime;
    private void OnCheckBoxTimerEnabledCheckedChanged(object sender, EventArgs e)
    {
        _StartTime = DateTime.UtcNow;
        timer.Enabled = checkBoxTimerEnabled.Checked;
    }
    private void OnTimerTick(object sender, System.EventArgs e)
    {
        var now = DateTime.UtcNow;
        labelTimeElapsed.Text = (now - _StartTime).ToString("h'h 'm'm 's's'");
    }

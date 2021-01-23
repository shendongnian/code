    public void runTimerTick(object sender, EventArgs e)
    {
        if (!this.StatusStrip.Visible)
            return;
        TimeSpan totalRunTime = DateTime.Now - this.RunStartTime;
        this.StatusLabelRunTime.Text =
        String.Format(ObjectStrings.SsgFormRunTime,
                              totalRunTime.Hours, 
                              totalRunTime.Minutes, 
                              totalRunTime.Seconds);
    }
    

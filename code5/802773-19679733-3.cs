    public void runTimerTick(object sender, EventArgs e)
    {
        TimeSpan totalRunTime = DateTime.Now - this.RunStartTime;
        this.StatusLabelRunTime.Text =
            String.Format("Elapsed time {0:00}:{1:00}:{2:00}.",
                          totalRunTime.Hours, 
                          totalRunTime.Minutes, 
                          totalRunTime.Seconds);
    }
    

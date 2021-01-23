    int count;
    int tmrInterval = 1000; //1 sec
    private void tPeriodic_Tick(object sender, EventArgs e)
    {
        count++;
        lTickCount.Text = count.ToString();
    }
    private void TickCounter_ValueChanged(object sender, EventArgs e)
    {
        if (TickCounter.Value == 0)
        {
            return; // or stop the timer
        }
        tPeriodic.Interval = TickCounter.Value * tmrInterval;
    }

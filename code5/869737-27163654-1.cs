    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime now = DateTime.Now;
            DateTime stopTime = now.Date.AddHours(23).AddMinutes(50); // This is 11:50 pm, don't hard code
            if (stopTime < now) // If in the past add a day
                stopTime = stopTime.AddDays(1);
            TimeSpan timespan = (stopTime - now); // Get the difference between now and the alarm time
            // Now set the timer for the difference
            Timer1.Interval = (int)Math.Round(timespan.TotalMilliseconds); // May want to tweak the rounding
            Timer1.Enabled = true;
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //Your  Logic  To run
        DateTime now = DateTime.Now;
        DateTime stopTime = now.Date.AddHours(23).AddMinutes(50); // This is 11:50 pm, don't hard code
        if (stopTime < now) // If in the past add a day
            stopTime = stopTime.AddDays(1);
        TimeSpan timespan = (stopTime - now); // Get the difference between now and the alarm time
        // Now set the timer for the difference
        Timer1.Interval = (int)Math.Round(timespan.TotalMilliseconds); // May want to tweak the rounding
        Timer1.Enabled = true;
    }
}

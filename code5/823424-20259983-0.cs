    DateTime startTime;
    protected void btnStartTime_Click(object sender, EventArgs e)
    {
        startTime = DateTime.Now;            
        lblStartTime.Text = startTime.ToString("HH:mm:ss tt");            
    }
    protected void btnEndTime_Click(object sender, EventArgs e)
    {            
        var workDuration = DateTime.Now.Subtract(startTime).TotalMinutes;
        lblEndTime.Text = ("The Work duration is "+workDuration);
    }

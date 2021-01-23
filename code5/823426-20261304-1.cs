    private const string StartTimeSessionKey= "StartTimeSessionKey";
    protected void btnStartTime_Click(object sender, EventArgs e)
    {
        var startTime = DateTime.Now;
        Session[StartTimeSessionKey] = startTime;
    }
    protected void btnEndTime_Click(object sender, EventArgs e)
    {
        var startTime = (DateTime)Session[StartTimeSessionKey];
        var workDuration = DateTime.Now.Subtract(startTime).TotalMinutes;
        lblEndTime.Text = ("The Work duration is " + workDuration);
    }

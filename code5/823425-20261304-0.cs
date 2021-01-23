    private const string StartTimeViewstateKey = "StartTimeViewstateKey";
    protected void btnStartTime_Click(object sender, EventArgs e)
    {
        var startTime = DateTime.Now;
        ViewState[StartTimeViewstateKey] = startTime.ToString(CultureInfo.InvariantCulture);
    }
    protected void btnEndTime_Click(object sender, EventArgs e)
    {
        var startTime = DateTime.Parse((string)ViewState[StartTimeViewstateKey], CultureInfo.InvariantCulture);
        var workDuration = DateTime.Now.Subtract(startTime).TotalMinutes;
        lblEndTime.Text = ("The Work duration is " + workDuration);
    }

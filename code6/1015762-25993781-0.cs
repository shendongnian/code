    int hour = 0;
    int minute = 0;
    try
    {
        hour = int.Parse(this.HourTextBox.Text);
        minute = int.Parse(this.MinuteTextBox.Text);
    }
    catch
    {
    }
    var currentAlarmTime = DateTime.Today.AddHours(hour).AddMinutes(minute);
    var timeLeftToSleep = currentAlarmTime - DateTime.Now;
    this.timeLeftToSleepLabel.Text = string.Format("{0}:{1}", timeLeftToSleep.TotalHours, timeLeftToSleep.Minutes);

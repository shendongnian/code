    private void timer_Tick(object sender, EventArgs e)
    {
        if (hour < 23)
        {
            hour += step;
            lblTimerHour.Text = hour.ToString("00");
        }
    }

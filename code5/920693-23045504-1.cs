    private TimeSpan countDownTime = TimeSpan.Zero;
    
    private void timer_CountDown_Tick(object sender, EventArgs e)
    {
        if(countDownTime.TotalMinutes < 1)
        {
            label_Hours.ForeColor = Color.Red;
            label_Minutes.ForeColor = Color.Red;
            label_Seconds.ForeColor = Color.Red;
            label8.ForeColor = Color.Red;
            label10.ForeColor = Color.Red;
        }
    
        if(countDownTime == TimeSpan.Zero)
        {
            timer_CountDown.Stop();
            textBox_Seconds.Enabled = true;
            textBox_Minutes.Enabled = true;
            textBox_Hours.Enabled = true;
            button_Start.Enabled = true;
        }
        else
        {
            countDownTime = countDownTime.Add(TimeSpan.FromSeconds(1).Negate());
    
            label_Hours.Text = ts.ToString("hh");
            label_Minutes.Text = ts.ToString("mm");
            label_Seconds.Text = ts.ToString("ss");
        }
    }

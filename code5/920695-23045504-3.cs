    private TimeSpan countDownTime = TimeSpan.Zero;
    
    private void timer_CountDown_Tick(object sender, EventArgs e)
    {
        if(countDownTime == TimeSpan.Zero)
        {
            timer_CountDown.Stop();
            textBox_Seconds.Enabled = true;
            textBox_Minutes.Enabled = true;
            textBox_Hours.Enabled = true;
            button_Start.Enabled = true;
            return;
        }
        countDownTime = countDownTime.Add(TimeSpan.FromSeconds(1).Negate());
        label_Hours.Text = countDownTime.ToString("hh");
        label_Minutes.Text = countDownTime.ToString("mm");
        label_Seconds.Text = countDownTime.ToString("ss");
        if(countDownTime.TotalSeconds < 10)
        {
            label_Hours.ForeColor = Color.Red;
            label_Minutes.ForeColor = Color.Red;
            label_Seconds.ForeColor = Color.Red;
            label8.ForeColor = Color.Red;
            label10.ForeColor = Color.Red;
        }
        else if (countDownTime.TotalMinutes < 1)
        {
            label_Hours.ForeColor = Color.Orange;
            label_Minutes.ForeColor = Color.Orange;
            label_Seconds.ForeColor = Color.Orange;
            label8.ForeColor = Color.Orange;
            label10.ForeColor = Color.Orange;
        }
    }
    private void button_Start_Click(object sender, EventArgs e)
    {
        button_Pause.Enabled = true;
        button_Stop.Enabled = true;
    
        if(paused != true)
        {
            int hours = int.Parse(textBox_Hours.Text);
            int minutes = int.Parse(textBox_Minutes.Text);
            int seconds = int.Parse(textBox_Seconds.Text) + 1;
          
            this.countDownTime = new TimeSpan(hours,minutes,seconds);         
            
            textBox_Hours.Enabled = false;
            textBox_Minutes.Enabled = false;
            textBox_Seconds.Enabled = false;
            button_Start.Enabled = false;
            timer_CountDown.Start();
        }
    }

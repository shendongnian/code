    private System.Timers.Timer timer = new System.Timers.Timer();
    public Form1()
    {
        timer.Enabled = false;
        timer.AutoReset = true;
        timer.Elapsed += timerEvent;
    }
    private void TimerButton_Click(object sender, EventArgs e)
    {
        getTime = ImgTimeInterval.Text;
        bool isNumeric = int.TryParse(ImgTimeInterval.Text, out timerMS); //if number place number in timerMS
        label2.Text = isNumeric.ToString();
        if (isNumeric)
        {
            timer.Interval = timerMS;
            timer.Enabled = true;
        }
    }

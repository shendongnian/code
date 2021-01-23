    private Timer timer = new Timer();
    private void button1_Click(object sender, EventArgs e)
    {
        timer.Interval = 5000; // interval length
        timer.Tick += TimerOnTick; 
        timer.Enabled = true; // activate timer
        button1.Text = "Start";
    }
    private void TimerOnTick(object sender, EventArgs eventArgs)
    {
        timer.Enabled = false; // deactivate timer
        button1.Text = "Stop";
    }

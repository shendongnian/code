    private void Form1_Load(object sender, EventArgs e)
            {
                ControlTimerInbox.Interval=1000;//for 1 second
                ControlTimerInbox.Enabled = true;
                ControlTimerInbox.Start();
    
                StatusTimer.Interval=1000;//for 1 second
                StatusTimer.Enabled = true;
                StatusTimer.Start();
    
    
            }

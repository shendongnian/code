    Timer timerSwitchOn;
    public SomeConstructor()
    {
        timerSwitchOn = new Timer(){Interval = 10*1000}; // 10 seconds
        timerSwitchOn.Tick += new EventHandler(timerSwitchOn_Tick);
    }
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {    
       if (starterRight.SelectedIndex == 1)
       {
          //starter is on 
          starterRight.Enabled = false;
          timerSwitchOn.Start();
       }
    }
    void timerSwitchOn_Tick(object sender, EventArgs e)
    {
        timerSwitchOn.Stop();
        starterRight.Enabled = true;
        // set selected index back to 0
        starterRight.SelectedIndex = 0;
    }

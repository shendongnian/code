    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private void button1_Click(object sender, EventArgs e)  // event handler of your button
    {                
        timer.Interval = 30000; // here time in milliseconds
        timer.Tick += timer_Tick;
        timer.Start();
        button1.Enabled = false;
        // place get random code here
    }
    
    void timer_Tick(object sender, System.EventArgs e)
    {
        button1.Enabled = true;
        timer.Stop();
    }

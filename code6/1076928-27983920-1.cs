    private void button2_Click(object sender, EventArgs e)
    {
        stopTheTimer = false;
        YourCommonMethod();
        button2.Enabled = false;
        timer1.Tick += timer1_Tick
        timer1.Interval = 5000;
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        YourCommonMethod();
    }
    private void YourCommonMethod()
    {
        // execute your 'random' code here
        if(stopTheTimer)
        {
            timer1.Stop();
            timer1.Tick -= timer1_Tick;  // disconnect the event handler 
            button2.Enabled = true;
        }
    }

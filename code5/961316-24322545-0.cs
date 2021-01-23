    private void button1_Click(object sender, EventArgs e)
    {
        timer1.Interval= 20*1000; //20 seconds
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        timer1.Stop();
        timer2.Start(); //or timer2.Enabled=true;
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        //do whatever you want in timer2 Tick event handler
    }

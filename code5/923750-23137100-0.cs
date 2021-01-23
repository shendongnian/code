    private void Form1_Load(object sender, EventArgs e)
    {
        Timer timer = new Timer();
        timer.Interval = (10 * 1000); // 10 secs
        timer.Tick += new EventHandler(timer_Tick);
        timer.Start();
    }
    private void timer_Tick(object sender, EventArgs e)
    {
       //refresh here...
    }

    void Form1_Load(object sender, EventArgs e)
    {
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 1000;
        timer.Tick += timer_Tick;
        timer.Start();
    }
    private int time = 0;
    void timer_Tick(object sender, EventArgs e)
    {
        label1.Text = time.ToString();
        time++;
    }

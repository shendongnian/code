    Stopwatch stopWatch = new Stopwatch();
    private void button1_Click(object sender, EventArgs e)
    {
        // get system time to the  Start time 
        lblCurrentTime.Text = DateTime.Now.ToShortTimeString(); 
        stopWatch.Start();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        stopWatch.Stop();
        textBox1.Text = DateTime.Now.ToShortTimeString();
        lblCurrentPrice.Text = Stopwatch.Elapsed.TotalMinutes; 
    }

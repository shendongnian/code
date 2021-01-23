    private void Form1_Load(object sender, EventArgs e)
    {
        splashScreenTimer.Enabled = true;
        splashScreenTimer.Start();
        splashScreenTimer.Interval = 30;
        progressBar.Maximum = 100;
        splashScreenTimer.Tick += new EventHandler(timer_Tick);
    }
    int waitingTime = 0;
    private void timer_Tick(object sender, EventArgs e)
    {
        if (progressBar.Value < 100)
        {
            progressBar.Value++;
        }
        else
        {
            if (waitingTime++ > 35)
                this.Close();
        }
    }

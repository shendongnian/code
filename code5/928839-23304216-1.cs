    private void YourFunction()
    {
        Timer tm = new Timer();
        tm.Interval = 5000;
        tm.Tick += timerTick;
        PictureBox1.Visible = false;
        tm.Enabled = true;
        tm.Start();
    }
    private void timerTick(object sender, EventArgs e)
    {
        PictureBox1.Visible = true;
        ((Timer) sender).Stop();
    }

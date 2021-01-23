    private void label1_Click(object sender, EventArgs e)
    {
        var startTime = DateTime.Now;
        var counter = (TimeSpan.FromMinutes(1)).ToString("m\\:ss");
        if (timer1 == null || (timer1 != null && counter == 0)) return;
        timer1 = new Timer();
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Interval = 1000;
        timer1.Start();
        label1.Text = counter.ToString();
    }

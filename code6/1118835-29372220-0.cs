    private DateTime startTime;
    
    private void timerTick(Object obj, EventArgs args) {
        Button01text1.Text =
            (TimeSpan.FromMinutes(1) - (DateTime.Now - startTime))
            .ToString("hh\\:mm\\:ss");
        Button01textleft.Text =
            (TimeSpan.FromMinutes(1) - (DateTime.Now - startTime))
            .ToString("hh\\:mm\\:ss");
        if (Button01text1.Text == "00:00:30")
        {
            Button01.BackColor = Color.FromName("Orange");
            Button01textleft.BackColor = Color.FromName("Orange");
        }
        else if (Button01text1.Text == "00:00:00")
        {
            Button01.BackColor = Color.FromName("Red");
            Button01textleft.BackColor = Color.FromName("Red");
            timer2.Stop();
        }
    }
    public void Button01_Click(object sender, EventArgs e)
    {
        startTime = DateTime.Now;
        Button01.BackColor = Color.FromName("Green");
        Button01textleft.BackColor = Color.FromName("Green");
        timer2.Tick -= timerTick;
        timer2.Tick += timerTick;
        timer2.Enabled = true;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        time++;
        if (Form8.level.Equals("expert"))
        {
            timer1.Interval = 10000;
            if (time == 10000)
            {
                timer1.Stop();
                MessageBox.Show("time ended");
            }
        }
        else
        {
            timer1.Equals(60000);
            if (time==60000)
            {
                timer1.Stop();
                MessageBox.Show("time ended");
            }
        }
    }

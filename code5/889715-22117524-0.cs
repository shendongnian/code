    DateTime date = DateTime.Now;
    private void timer1_Tick(object sender, EventArgs e)
    {
        date = date.AddSeconds(1);
        label1.Text = date.ToString("mm:ss");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        timer1.Start();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        timer1.Stop();
    }

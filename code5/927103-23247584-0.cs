    private void button1_Click(object sender, EventArgs e)
    {
        label5.Visible = true;
        timer2.Interval = 3000;
        timer2.Enabled = true;
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        label5.Visible = false;
        timer2.Enabled = false;
    }

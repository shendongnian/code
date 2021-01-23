    private void btnProveri_Click(object sender, EventArgs e)
    {
        lblRezultat.Text = DateTime.Now.ToString();
        var timer = new System.Timers.Timer(1800);
        timer.Elapsed += timer1_Tick;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        MessageBox.Show(DateTime.Now.ToString());
    }

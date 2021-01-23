    private void btnProveri_Click(object sender, EventArgs e)
    {
        lblRezultat.Text = DateTime.Now.ToString();
        var timer = new System.Timers.Timer(1800);
        timer.Start();
        timer.Elapsed += timer1_Tick;
    }
    private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
    {
        MessageBox.Show(DateTime.Now.ToString());
    }

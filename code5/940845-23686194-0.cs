    Timer sleepTimer = new Timer(20000); //Creates a timer for sleeping
    public MyClass()
    {
       sleepTimer.Elapsed += new EventHandler((s, e) => WakeUp());
    }
    private void BtnSleep_Click(object sender, EventArgs e)
    {
        if (PgbSleep.Value <= 250)
        {
            int temp = PgbSleep.Maximum - PgbSleep.Value;
            if (temp + PgbSleep.Value >= 300)
            {
                Timer2.Stop();
                sleepTimer.Start();
            }
        }
        else
        {
            MessageBox.Show("Your pokemon is not tired enough to sleep! try playing with it");
        }
    }
    private void WakeUp()
    {
        PgbSleep.Value = 300;
        Timer2.Start();
    }

    bool progress = false;
    private void Odeslat_Click(object sender, EventArgs e)
    {
        progress = true;
        timer1.Start();
        Thread thread = new Thread(Process);
        thread.IsBackground = true;
        thread.Start();        
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if(!progress)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            timer1.Stop();
        }else
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }
    }
    public void Process()
    {
        foreach (string Prodejna in SeznamProdejen)
        {
            i = i + 1;
            Update1(i);
           //some long task
        }
        progress = false;
    }

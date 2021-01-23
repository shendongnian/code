    private int Counter;
    private void cmdGo_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        t.Interval = 60000; // specify interval time - 1 minute
        t.Tick += new EventHandler(timer_Tick);
        t.Start();
    }
    // Every 1 min this timer fires...
    void timer_Tick(object sender, EventArgs e)
    {
        // If it has been 16 minutes then run RunMethod1
        if (++Counter >= 16)
        {
            Counter = 0;
            RunMethod1();         
            return;
        }
        // Not yet been 16 minutes so just run RunMethod2
        RunMethod2();
    }

    private int Counter;
    // Every 1 min this timer fires...
    void timer_Tick(object sender, EventArgs e)
    {
        RunMethod1();
        if (++Counter < 16)
        {
            return;
        }
        Counter = 0;
        RunMethod2();
    }

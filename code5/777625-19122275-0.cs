    private int tickCount = 0;
    private const int tick_wait = 30; 
    private void tmrDelay_Tick(object sender, EventArgs e)
    { 
        tickCount++; 
        if (tickCount > tick_wait)
        {
            DoSomething();
            tickCount = 0;   
        }
    }
    private void btnActivity_Click(object sender, EventArgs e)
    {
        tickCount = 0;
    }
 

    private PerformanceCounter pcMemory;
    
    private void InitPerfmon()
    {
    	this.pcMemory = new PerformanceCounter();
    	this.pcMemory.CounterName = "Available MBytes";
    	this.pcMemory.....
    	...
    	this.pcMemory.NextValue();
    }
    
    private void tmrMemory_Tick(System.Object sender, System.EventArgs e)
    {
    	this.pgFaults.Text = this.pcMemory.NextValue().ToString();
    }

    public MyForm()
    {
        InitializeComponent();
        cpuCounter = new PerformanceCounter();
        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
        cpuCounter.InstanceName = "_Total";
        ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        
        //It is better to add the timer via the Design View so it gets disposed properly when the form closes.
        //timer = new System.Windows.Forms.Timer();
        
        //This setup can be done in the design view too, you just need to call timer.Start() at the end of your constructor (On form load would be even better however, ensures all of the controls have their handles created).
        timer.Interval=1000;
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    //private System.Windows.Forms.Timer timer; //Added via Design View
    
    private PerformanceCounter cpuCounter;
    private PerformanceCounter ramCounter;
    private void Timer_Tick(object sender, EventArgs e)
    {
        label1.Text = "Cpu usage: :" + cpuCounter.NextValue() + "%";
        label2.Text = "Free ram : " + ramCounter.NextValue() + "MB";
    }

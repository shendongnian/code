    public MyForm()
    {
        InitializeComponent();
        cpuCounter = new PerformanceCounter();
        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
        cpuCounter.InstanceName = "_Total";
        ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        
        timer = new System.Windows.Forms.Timer();
        timer.Interval=1000;
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    private System.Windows.Forms.Timer timer;
    private PerformanceCounter cpuCounter;
    private PerformanceCounter ramCounter;
    private void Timer_Tick(object sender, EventArgs e)
    {
        label1.Text = "Cpu usage: :" + cpuCounter.NextValue() + "%";
        label2.Text = "Free ram : " + ramCounter.NextValue() + "MB";
    }

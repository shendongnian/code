    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private int hour = 0;
    private int step = 0;
    public Form1()
    {
        InitializeComponent();
        timer.Tick += timer_Tick;
        timer.Interval = 1000;
    }

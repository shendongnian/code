    private Stopwatch sw = new Stopwatch();
    private Timer timer = new Timer();
    public Form1()
    {
        InitializeComponent();
        timer.Tick += timer2_Tick;
    }
    private void buttonFourteen_Click(object sender, EventArgs e)
    {
        sw.Restart();
        timer.Start();
        var backgroundWorker = new BackgroundWorker();
        // Simulating a 10-second process for testing
        backgroundWorker.DoWork += (s, ea) => Thread.Sleep(TimeSpan.FromSeconds(10));
        backgroundWorker.RunWorkerCompleted += (s, ea) => timer.Stop();
        backgroundWorker.RunWorkerAsync();
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        timedisplay.Text = sw.Elapsed.ToString("g");
    }

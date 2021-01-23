    private TaskScheduler _uiScheduler;
    public Form1()
    {
        InitializeComponent();
        _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Thread thread1 = new Thread(DoStuff);
        thread1.Start();
        Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(500);
                    button1.Text +=".";
                }
            }, CancellationToken.None, TaskCreationOptions.None, _uiScheduler));
    }

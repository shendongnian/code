    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = dataModel;
    
        worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = true;
        worker.DoWork += (o, e) =>
        {
            //do a long running task
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(500);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
    
        };
        worker.RunWorkerCompleted += (o, e) =>
        {
            if (e != null && e.Cancelled)
            {
                startTheWorker();
                return;
            }
            //TODO: I AM DONE!
        };
    }
    
    BackgroundWorker worker;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (worker != null && worker.IsBusy)
            worker.CancelAsync();
        else if(worker != null && !worker.CancellationPending)
            startTheWorker();
    }
    
    void startTheWorker()
    {
        if (worker == null)
            throw new Exception("How come this is null?");
        worker.RunWorkerAsync();
    }

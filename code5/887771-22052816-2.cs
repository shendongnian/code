    public Form1()
    {
        InitializeComponent();
        backgroundWorker1.WorkerReportsProgress = true;
    }
    private void WriteToFileMethod()
    {
        // your routine here
    }
    
    private void button_Click(object sender, EventArgs e)
    {
        progressBar.Maximum = 100;
        progressBar.Step = 1;
        progressBar.Value = 0;
        backgroundWorker.RunWorkerAsync();
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var backgroundWorker = sender as BackgroundWorker;
        for (int i = 0; i < workSize; i++)
        {
            WriteToFileMethod();
            backgroundWorker.ReportProgress((i * 100) / workSize);
        }
    }
    
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }

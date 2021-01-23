    public partial class App : Application
    {
        private SplashScreenWindow SplashScreen { get { return (SplashScreenWindow)this.MainWindow; } }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerAsync();
        }
        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            new MainWindow().Show();
            SplashScreen.Close();
        }
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SplashScreen.ValueProgressBar = e.ProgressPercentage;
        }
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            for (int i = 0; i <= 100; i += 10)
            {
                backgroundWorker.ReportProgress(i, "Chargement en cours : " + i);
                Thread.Sleep(500);
            }
        }
    }

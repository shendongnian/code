    public void Foo()
    {
        SplashWindow splash = new SplashWindow();
        splash.Loaded += (_, args) =>
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.ProgressChanged += (s, progressArgs) =>
                splash.Text = progressArgs.UserState as string;
            worker.DoWork += (s, workerArgs) =>
            {
                Thread.Sleep(5000);//placeholder for real work;
                worker.ReportProgress(0, "Finished First Task");
                Thread.Sleep(5000);//placeholder for real work;
                worker.ReportProgress(0, "Finished Second Task");
                Thread.Sleep(5000);//placeholder for real work;
                worker.ReportProgress(0, "Finished Third Task");
            };
            worker.RunWorkerCompleted += 
                (s, workerArgs) => splash.Close();
            worker.RunWorkerAsync();
        };
        splash.ShowDialog();
    }

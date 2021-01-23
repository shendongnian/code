    public Class Main
    {
        public Main( ... )
        {
            BackgroundWorker worker = new BackgroundWorker()
            worker.WorkerReportsProgress = true;
            // Register to BackgroundWorker-Events
            worker.DoWork += threadWorker_DoWork;
            worker.ProgressChanged += threadWorker_ProgressChanged;
        }
    }

        //Put this line on class level and only initialize it once.
        MyHeavyWorker = new System.ComponentModel.BackgroundWorker();
        //Call this once to initialize your Backgroundworker
        public InitializeBackgroundWorker()
        {
            MyHeavyWorker.WorkerReportsProgress = true;
            MyHeavyWorker.WorkerSupportsCancellation = true;
            MyHeavyWorker.ProgressChanged += MyHeavyWorker_ProgressChanged;
            MyHeavyWorker.DoWork += MyHeavyWorker_DoWork;
            MyHeavyWorker.RunWorkerCompleted += MyHeavyWorker_RunWorkerCompleted;
        }

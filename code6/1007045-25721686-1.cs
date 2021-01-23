            BackgroundWorker _worker = new BackgroundWorker();
    
            public Cnt()
            {
                InitializeComponent();
                _worker.DoWork += WorkerOnDoWork;
                _worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
                //start your work
                _worker.RunWorkerAsync();    
            }
    
            private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                //Worker completed event
            }
    
            private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
            {
                //Do   
            }

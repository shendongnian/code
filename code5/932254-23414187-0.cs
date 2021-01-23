        public void btnNewWindow_Click(object sender, EventArgs args)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += WorkerOnDoWork;
            worker.ProgressChanged += WorkerOnProgressChanged;
            worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
            worker.RunWorkerAsync();
        }
        private List<string> _data = new List<string>();
        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            //Work has finished. Launch new UI from here.
            Form2 f2 = new Form2(_data);
            f2.Show();
        }
        private ProgressBar progressBar1;
        void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Log process here
        }
        private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            //Perform work you need to load the data.
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                _data.Add("Test" + i);
            }
        }

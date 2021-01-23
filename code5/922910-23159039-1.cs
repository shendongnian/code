        private DataTable dt = new DataTable();
        void Start()
        {
            dt.RowChanged += new DataRowChangeEventHandler(dt_RowChanged);
            progressBar1.Maximum = dtRowsCount;
            bgWorker.RunWorkerAsync();
        }
        void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            bgWorker.ReportProgress(1);
        }
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Your work
        }
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += e.ProgressPercentage;
        }

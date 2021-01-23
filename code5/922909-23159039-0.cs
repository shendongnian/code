        private DataTable dt = new DataTable();
        void Start()
        {
            dt.RowChanged += new DataRowChangeEventHandler(dt_RowChanged);
            bgWorker.RunWorkerAsync();
        }
        void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            bgWorker.ReportProgress(1);
            if (progressBar1.Value == 0) //Or get the count before the filling
                progressBar1.Maximum = e.Row.Table.Rows.Count;
        }
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Your work
        }
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += e.ProgressPercentage;
        }

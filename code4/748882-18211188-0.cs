    BackgroundWorker _worker;
    // executes on another thread
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        int c = 0;
        OdbcConnection cn = openOdbcDB();
        foreach (DataSet ds in allDataSets)
        {
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    insertIntoDatabaseCurrentRecord(dr);
                }
            }
            // do not update UI elements here, but in ProgressChanged event
            //pbMain.Value = pbMain.Value + (33 / totalFiles);
            c++;
            worker.ReportProgress(c); // call ProgressChanged event of the worker and pass a value you can calculate the percentage from (I choose c, since it is the only calculated value here)
        }
        cn.Close();
        cn.Dispose();
    }
    // gets called on your main thread
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // update the progressbar here.
        // e.ProgressPercantage holds the value passed in DoWork.
    }

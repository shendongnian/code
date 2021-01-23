    public void myFunc()
    {
        lbl_status.Text = "Loading ... Please Wait";
        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += bw_DoWork;
        bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        bw.RunWorkerAsync();
    }

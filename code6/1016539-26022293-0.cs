    BackgroundWorker bw;
    private void Form1_Load(object sender, EventArgs e)
    {
        bw = new BackgroundWorker();
        bw.WorkerReportsProgress = true; //allows call backs
        bw.DoWork += bw_DoWork;
        bw.ProgressChanged += bw_ProgressChanged;
        bw.RunWorkerAsync(); //run the worker
    }
    void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var message = e.UserState;
        //do something with the UserState, like flash a light
    }
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        //do your logic here, when you want to "report progress"
        //use the following lines
        BackgroundWorker localBW = (BackgroundWorker)sender;
        localBW.ReportProgress(0, "hey, flash please"); // or something else
        //when you are all done, you can pass something back
        e.Result = "I'm done now";
    }

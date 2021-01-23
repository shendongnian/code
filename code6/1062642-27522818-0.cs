    private void ReportProgress(Tuple<int,string> progress)
    {        
        pbar.Value=progress.Item1;
        status.Text=progress.Item2;
    }
    public void StartProcessing()
    {
        IProgress<Tuple<int,string>> progress=new Progress<Tuple<int,string>>(ReportProgress);
        var workerClass=new MyWorkerClass();
        workerClass.DoWork(progress);
        ....
    }

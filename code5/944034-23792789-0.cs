    public void OnStart(string[] args) 
    {
        var worker = new Thread(DoWork);
        worker.Name = "MyWorker";
        worker.IsBackground = false;
        worker.Start();
    }
    void DoWork()
    {
        // long running task
    }

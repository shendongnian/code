    void StartWorker()
    {
        var progress = new Progress<int>(UpdateProgressBar);
        
        worker1.Start(progress)
    }
    
    
    void UpdateProgressBar(int Value)
    {
        //This code is invoked on the UI thread
        myProgressBar.Value = value;
    }
    
    //Elsewhere in Worker1
    void Start(IProgress<int> progress)
    {
    
        int count=0;
        Worker2 worker2 = new Worker2();
        while (bytesRead =(readData() !=0) 
        {
            count++;
            worker2.doWork();
            progress.Report(count);
        }
    }
